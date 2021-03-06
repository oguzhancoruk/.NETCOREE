using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Common;
using WebApi.DBOperations;
namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {   
        private readonly BookStoreDbContext _dbContext; 
        public int BookId {get;set;}
        public UpdateBookModel Model{get;set;}
        public  UpdateBookCommand(BookStoreDbContext dbContext)
        {
           _dbContext=dbContext;
        }
        public void Handle()
        {
          var book=_dbContext.Books.SingleOrDefault(x=>x.Id==BookId);
          if(book is null)
          throw new InvalidOperationException("Kitap bulunamad─▒"); 
  
          book.GenreId=Model.GenreId!=default ? Model.GenreId :book.GenreId;
       
         book.Title=Model.Title!=default ? Model.Title:book.Title;

         _dbContext.SaveChanges();
  
        
         


        }
    }

    public class UpdateBookModel
    {  
        public string Title{get;set;}
       public int GenreId{get;set;}  
       public int PageCount{get;set;}
       public string PublishDate {get;set;}


    }
    
}