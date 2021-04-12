using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WookieBooksApp.Models
{
    public class DefaultDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookContext(serviceProvider.GetRequiredService<DbContextOptions<BookContext>>()))
            {
                if (context.Books.Any())
                {
                    // Data was already seeded
                    return;
                }

                context.Books.AddRange
                (
                    new Book { Id = 1, Title = "Murder on the Orient Express", Description = "Murder on the Orient Express is a work of detective fiction by English writer Agatha Christie featuring the Belgian detective Hercule Poirot. It was first published in the United Kingdom by the Collins Crime Club on 1 January 1934.", Author = "Agatha Christie", CoverImage = "murderontheorientexpress.png", Price = 10 },
                    new Book { Id = 2, Title = "The Murder of Roger Ackroyd", Description = "The Murder of Roger Ackroyd is a work of detective fiction by British writer Agatha Christie, first published in June 1926 in the United Kingdom by William Collins, Sons and in the United States by Dodd, Mead and Company. It is the third novel to feature Hercule Poirot as the lead detective.", Author = "Agatha Christie", CoverImage = "themurderofroger.png", Price = 15 }
                );

                context.SaveChanges();
            }
        }
    }
}
