using System;
using Books;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Linq;


namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Testing start!\n");
            
            //042 = " 
            const string regex = @"(add|update|delete)\s+(\w+)\s+((\042([^\042]+)\042\s*)|((\d{1})\s+(\042([^\042]+)\042\s*))|(\d{1}))";
            
            Console.WriteLine("You can use such models names: Pages, NavLink, RP in your commands.");
            
            var addPageExample = "add Pages \" { UrlName:'Test', Title: 'FirstConsolePage', Description: 'Just some words', Content:'blabla' } \"";
            var addLinkExample = "add NavLink \" { NavLinkTitle: 'FCT', ParentLinkId: '1', PageId: '2', Position:'Last' } \"";
            var updateNavLink = "update NavLink 1 \" { NavLinkTitle:'Test1'} \"";
            var deletePage = "delete Pages 4 ";
            var delRP = "delete RP 2";
            var easyList = "list all";

            using( var db = new BooksContext() )
            {
                Console.Write("Commands examples: \n{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n",addPageExample,addLinkExample,updateNavLink,deletePage,delRP,easyList);
                
                Console.Write("\n\nNow enter your query (q - to exit)\n->");
                var input = Console.ReadLine();
                bool oncemore = input == "q" ? false:true; 
                while(oncemore)
                {
                    if(input=="list all")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Pages:");
                        foreach( var page in db.Pages )
                        {
                            Console.WriteLine("PageID {0} -> {1} - {2} - {3} - {4} - {5}",page.PageID, page.UrlName,page.Title, page.Description, page.Content, page.AddedDate);
                        }
                        
                        Console.WriteLine("\nLinks:");
                        foreach( var link in db.Links )
                        {
                            Console.WriteLine("LinkId  {0} -> {1} - {2} - {3} - {4}",link.NLId, link.NavLinkTitle, link.ParentLinkId, link.PageId, link.Position);
                        }
                        
                        Console.WriteLine("\nRelated Pages:");
                        foreach ( var rp in db.RelPages )
                        {
                            Console.WriteLine("Related pages {0} -> PageID1: {1} - PageID2: {2} ",rp.RowId, rp.PageId1, rp.PageId2); 
                        }
                    }
                    else{
                        try
                        {
                            var objectsMatches = Regex.Matches(input, regex);
                            Match match = objectsMatches[0];
                            switch ( match.Groups[1].Value.ToString() )
                            {
                                case "add":
                                    Console.Write("\nAdding ");
                                    switch (match.Groups[2].Value.ToString())
                                    {
                                        case "Pages":
                                            Console.Write("Page...\n ");
                                            var p = JsonConvert.DeserializeObject<Page>( match.Groups[5].Value.ToString() );
                                            
                                            db.Pages.Add(new Page { UrlName = p.UrlName, Title = p.Title, Description = p.Description, Content = p.Content, AddedDate = DateTime.Now } );
                                            Console.WriteLine("Inserted Page -> {0} - {1} - {2} - {3} - {4}",p.UrlName, p.Title, p.Description, p.Content, DateTime.Now);
                                            break;
                                        case "NavLink":
                                            Console.Write("Link...\n ");
                                            var link = JsonConvert.DeserializeObject<NavLink>( match.Groups[5].Value.ToString() );
                                            
                                            db.Links.Add(new NavLink{ NavLinkTitle = link.NavLinkTitle, ParentLinkId = link.ParentLinkId, PageId = link.PageId, Position = link.Position });
                                            Console.WriteLine("Inserted Link -> {0} - {1} - {2} - {3}", link.NavLinkTitle, link.ParentLinkId, link.PageId, link.Position);
                                            break;
                                        case "RP":
                                            Console.Write("Related Pages...\n ");
                                            var rp = JsonConvert.DeserializeObject<RelatedPages>( match.Groups[5].Value.ToString() );

                                            db.RelPages.Add(new RelatedPages { PageId1 = rp.PageId1, PageId2 = rp.PageId2 } );
                                            Console.WriteLine("Inserted related pages -> {0} - {1} ", rp.PageId1, rp.PageId2); 
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "update":
                                    Console.WriteLine("\nUpdating..");
                                    switch (match.Groups[2].Value.ToString())
                                    {
                                        case "Pages":
                                            //deserializing
                                            var page = JsonConvert.DeserializeObject<Page>( match.Groups[9].Value.ToString() );
                                            
                                            //getting page that we want to update
                                            var pageToUpdate = db.Pages.Single(p => p.PageID == Int32.Parse(match.Groups[7].Value));
                                            var updt = pageToUpdate.PageID;
                                            
                                            //update field if it was in json structure, else leave the previous one value
                                            pageToUpdate.UrlName =  page.UrlName!=null ? page.UrlName : pageToUpdate.UrlName;
                                            pageToUpdate.Title =  page.Title!=null ? page.Title : pageToUpdate.Title;
                                            pageToUpdate.Description =  page.Description!=null ? page.Description : pageToUpdate.Description;
                                            pageToUpdate.Content =  page.Content!=null ? page.Content : pageToUpdate.Content;
                                            
                                            Console.WriteLine("PageID {0} was updated", updt);
                                            break;
                                        case "NavLink":
                                            //deserializing
                                            var jsonLink = JsonConvert.DeserializeObject<NavLink>( match.Groups[9].Value.ToString() );
                                            
                                            //getting link that we want to update
                                            var linkToUpdate = db.Links.Single(lnk => lnk.NLId == Int32.Parse(match.Groups[7].Value));
                                            var updtLinkID = linkToUpdate.NLId;
                                            
                                            //update field if it was in json structure, else leave the previous one value
                                            linkToUpdate.NavLinkTitle =  jsonLink.NavLinkTitle != null ? jsonLink.NavLinkTitle : linkToUpdate.NavLinkTitle;
                                            linkToUpdate.ParentLinkId =  jsonLink.ParentLinkId != 0 ? jsonLink.ParentLinkId : linkToUpdate.ParentLinkId;
                                            linkToUpdate.PageId =  jsonLink.PageId != 0 ? jsonLink.PageId : linkToUpdate.PageId;
                                            linkToUpdate.Position =  jsonLink.Position != null ? jsonLink.Position : linkToUpdate.Position;
                                            
                                            Console.WriteLine("LinkID {0} was updated", updtLinkID);
                                            
                                            break;
                                        case "RP":
                                            var jsonRP = JsonConvert.DeserializeObject<RelatedPages>( match.Groups[9].Value.ToString() );

                                            //getting rp that we want to update
                                            var rpToUpdate = db.RelPages.Single(relp => relp.RowId == Int32.Parse(match.Groups[7].Value));
                                            var updtRPID = rpToUpdate.RowId;
                                            
                                            rpToUpdate.PageId1 =  jsonRP.PageId1 != 0 ? jsonRP.PageId1 : rpToUpdate.PageId1;
                                            rpToUpdate.PageId2 =  jsonRP.PageId2 != 0 ? jsonRP.PageId2 : rpToUpdate.PageId2;
                                            
                                            Console.WriteLine("Related pages with rowID {0} was updated", updtRPID);
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "delete":
                                    Console.Write("\nRemoving ");
                                    switch (match.Groups[2].Value.ToString())
                                    {
                                        case "Pages":
                                            Console.Write("Page...\n ");
                                            var pagetoDel = db.Pages.Single(p => p.PageID == Int32.Parse(match.Groups[3].Value));
                                            var rm = pagetoDel.PageID;
                                            db.Pages.Remove(pagetoDel);
                                            Console.WriteLine("PageID {0} was removed", rm);
                                            break;
                                        case "NavLink":
                                            Console.Write("Link...\n ");
                                            var linkToDelete = db.Links.Single(lnk => lnk.NLId == Int32.Parse(match.Groups[3].Value.ToString()));
                                            var dLinkID = linkToDelete.NLId;
                                            db.Links.Remove(linkToDelete);
                                            Console.WriteLine("LinkID {0} was removed", dLinkID);
                                            break;
                                        case "RP":
                                            Console.Write("Related Pages...\n ");
                                            var rpToDelete = db.RelPages.Single(relp => relp.RowId == Int32.Parse(match.Groups[3].Value));
                                            var dRPID = rpToDelete.RowId;
                                            db.RelPages.Remove(rpToDelete);
                                            Console.WriteLine("Related pages with rowID {0} were removed", dRPID);                                     
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }//general switch
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                            Console.WriteLine("  Message: {0}", ex.Message);
                        }
                    }
                    Console.Write("\nEnter new query (q - to exit)\n ->");
                    input = Console.ReadLine();
                    if(input=="q")
                        oncemore = false;
                }//while true

            }//using
            
            Console.WriteLine("\nSuccess! End.");
        }//main

    }//class program

}//namespace
