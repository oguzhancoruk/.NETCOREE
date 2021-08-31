using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Common;
using WebApi.DBOperations;


namespace WebApi.BookOperations.GetBooksDetail
{
    
    public class GetbooksDetailQuery
    {
        private readonly BookStoreDbContext _dbContext; 
        private readonly IMapper _maper;
        public int BookId{get;set;}
        public GetbooksDetailQuery(BookStoreDbContext dbContext,IMapper mapper)
        {
            _maper=mapper;
            _dbContext=dbContext;
        }

        public BookDetailViewModel Handle()
        {
         var book=_dbContext.Books.Where(book=>book.Id==BookId).SingleOrDefault();
        if(book is null)
        throw new InvalidOperationException("Kitap bulunamadı"); 
        BookDetailViewModel vm= _maper.Map<BookDetailViewModel>(book);
      
         return vm;
        }
    }
    public class BookDetailViewModel
    {
      
       public string Title{get;set;}
       public string Genre{get;set;}  
       public int PageCount{get;set;}
       public string PublishDate {get;set;}

    }
}