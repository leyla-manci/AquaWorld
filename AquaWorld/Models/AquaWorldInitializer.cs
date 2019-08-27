using System.Collections.Generic;
using System.Data.Entity;

namespace AquaWorld.Models
{
    public class AquaWorldInitializer : DropCreateDatabaseIfModelChanges<AquaWorldContext>
    {
        protected override void Seed(AquaWorldContext context)
        {
            List<Category> _categories = new List<Category>()
            {
                new Category(){ShortDesc="Tuzlu su balıkları",LongDesc="tuzlu su balıkları ....."},
                new Category(){ShortDesc="Tatlı su balıkları",LongDesc="Tatlı su balıkları ....."},
                new Category(){ShortDesc="Göl balıkları",LongDesc=" göl balıkları ....."},
                new Category(){ShortDesc="Akarsu balıkları",LongDesc="akarsu balıkları ....."},
                new Category(){ShortDesc="Akvaryum balıkları",LongDesc="akvaryum balıkları ....."},
                new Category(){ShortDesc="Deniz balıkları",LongDesc="deniz balıkları ....."}


            };
            foreach (var item in _categories)
            {
                context.categories.Add(item);
            }
            List<Fish> _fishes = new List<Fish>()
            {
                new Fish(){Name="Beta",ShortDesc="akvaryumda yaşar",LongDesc="yumurtaları erkek balık korur",FishImage="Beta.jpg",CategoryId=5},
                new Fish(){Name="Moli",ShortDesc="akvaryumda yaşar",LongDesc="yumurtaları erkek balık korur",FishImage="Moli.jpg",CategoryId=5},
                new Fish(){Name="Zebra",ShortDesc="akvaryumda yaşar",LongDesc="yumurtaları erkek balık korur",FishImage="Zebra.jpg",CategoryId=5},
                new Fish(){Name="Cüce Vatoz",ShortDesc="akvaryumda yaşar",LongDesc="yumurtaları erkek balık korur",FishImage="ccvatoz.jpg",CategoryId=5},
                new Fish(){Name="Karides",ShortDesc="akvaryumda yaşar",LongDesc="yumurtaları erkek balık korur",FishImage="karides.jpg",CategoryId=5},
                new Fish(){Name="Hamsi",ShortDesc="Deniz yaşar",LongDesc="yumurtaları erkek balık korur",FishImage="hamsi.jpg",CategoryId=6},
                new Fish(){Name="Sardalya",ShortDesc="Deniz yaşar",LongDesc="yumurtaları erkek balık korur",FishImage="sardalya.jpg",CategoryId=6},
                new Fish(){Name="Sarı Kanat",ShortDesc="akvaryumda yaşar",LongDesc="yumurtaları erkek balık korur",FishImage="Beta.jpg",CategoryId=5},
                new Fish(){Name="Prenses",ShortDesc="akvaryumda yaşar",LongDesc="yumurtaları erkek balık korur",FishImage="Beta.jpg",CategoryId=5},
                new Fish(){Name="Çekiç Boynuz",ShortDesc="Okyanusta yaşar",LongDesc="yumurtaları erkek balık korur",FishImage="Beta.jpg",CategoryId=1},
                new Fish(){Name="Lepisdes",ShortDesc="akvaryumda yaşar",LongDesc="yumurtaları erkek balık korur",FishImage="Beta.jpg",CategoryId=5},
                new Fish(){Name="Yumuşakça",ShortDesc="Denizde yaşar",LongDesc="yumurtaları erkek balık korur",FishImage="Beta.jpg",CategoryId=6},
                new Fish(){Name="Çöpçü",ShortDesc="akvaryumda yaşar",LongDesc="yumurtaları erkek balık korur",FishImage="Beta.jpg",CategoryId=5},
                new Fish(){Name="Hani balığı",ShortDesc="Denizde yaşar",LongDesc="yumurtaları erkek balık korur",FishImage="Beta.jpg",CategoryId=2},

            };

            foreach (var item in _fishes)
            {
                context.fishes.Add(item);

            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}