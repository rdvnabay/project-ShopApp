using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopAppDemo.Entities.Concrete;
using System.Linq;

namespace ShopAppDemo.DataAccessLayer.Concrete.EntityFrameworkCore
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<ShopAppContext>();

            context.Database.Migrate();

            if (!context.Products.Any())
            {
                var products = new[]
                {
                    new Product{Name="Phone",Price=2000, Image="1.jpg", Description="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır." },
                    new Product{Name="Laptop",Price=5000, Image="2.jpg",  Description="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır."},
                    new Product{Name="Tablet",Price=1000, Image="3.jpg",  Description="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır."},
                    new Product{Name="Keyboard",Price=40, Image="4.jpg",  Description="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır."},
                    new Product{Name="Bag",Price=100, Image="5.jpg",  Description="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır."},
                    new Product{Name="T-Shirt",Price=45, Image="6.jpg",  Description="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır." }
                };

                context.Products.AddRange(products);

                var categories = new[]
                {
                    new Category{Name="Electronics"},
                    new Category{Name="Furniture"},
                    new Category{Name="Other"}
                };

                context.Categories.AddRange(categories);

                var productsCategories = new[]
                {
                    new ProductCategory{Product=products[0],Category=categories[0]},
                    new ProductCategory{Product=products[1],Category=categories[1]},
                    new ProductCategory{Product=products[2],Category=categories[2]},
                    new ProductCategory{Product=products[2],Category=categories[0]},
                    new ProductCategory{Product=products[3],Category=categories[1]},
                    new ProductCategory{Product=products[3],Category=categories[2]},
                     new ProductCategory{Product=products[4],Category=categories[1]},
                    new ProductCategory{Product=products[5],Category=categories[2]}
                };

                context.AddRange(productsCategories);
                context.SaveChanges();
            }
        }
    }
}


