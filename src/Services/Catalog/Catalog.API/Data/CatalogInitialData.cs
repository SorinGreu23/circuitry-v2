using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        // Marten UPSERT will cater for existing records
        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() =>
        new List<Product>
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name =
                    "Laptop Apple MacBook Air 13-inch, True Tone, procesor Apple M1 , 8 nuclee CPU si 7 nuclee GPU, 8GB, 256GB, Space Grey, INT KB",
                Description =
                    "Cel mai subtire si mai usor notebook-ul nostru, complet transformat de cipul Apple M1. Viteza procesorului de pana la de 3,5 ori mai rapida. Viteza GPU-ului de pana la 5 ori mai rapida. Cel mai avansat motor neuronal pentru invatare automata de pana la de 9 ori mai rapida. Cea mai mare autonomie a bateriei vreodata pe un MacBook Air. Si un design silentios, fanless. Atata putere nu a fost niciodata atat de pregatita.",
                ImageFile = "macbook-air-13-inch-m1.jpg",
                Price = 3999.99M,
                Category = ["Laptops", "MacBook"],
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name =
                    "Laptop Apple MacBook Air 13-inch, cu procesor Apple M3, 8 nuclee CPU si 10 nuclee GPU, 16GB, 512GB, Space Grey, INT KB, Manual RO",
                Description =
                    "Subtire. Usor. M3ga puternic. MacBook Air rezolva lejer sarcini legate de munca sau de jocuri, iar cipul M3 ofera capabilitati si mai mari acestui laptop superportabil. Cu pana la 18 ore de autonomie a bateriei,1 poti lua MacBook Air oriunde cu tine, ca sa treci cu viteza prin tot ce ai de facut.",
                ImageFile = "macbook-air-13-m3.jpg",
                Price = 7699.99M,
                Category = ["Laptops", "Macbook"],
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name =
                    "Laptop Apple MacBook Pro 14-inch, cu procesor Apple M3, 8 nuclee CPU si 10 nuclee GPU, 512GB SSD, Space Grey, INT KB",
                Description =
                    "Cele mai avansate cipuri pe care le‑am creat vreodata. Pana la 22 de ore de autonomie a bateriei. Asta inseamna portabilitate profesionala de top. Ecran Liquid Retina XDR. Stralucit din toate punctele de vedere",
                ImageFile = "macbook-pro-14-m3.jpg",
                Price = 8399.99M,
                Category = ["Laptops", "Macbook"],
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name =
                    "Laptop Apple MacBook Pro 16\" cu procesor Apple M3 Max, 14 nuclee CPU si 30 nuclee GPU, 36GB, 1TB SSD, Space Black, INT KB",
                Description =
                    "Cele mai avansate cipuri pe care le‑am creat vreodata. Pana la 22 de ore de autonomie a bateriei. Asta inseamna portabilitate profesionala de top. Ecran Liquid Retina XDR. Stralucit din toate punctele de vedere",
                ImageFile = "macbook-pro-16-m3.jpg",
                Price = 18999.99M,
                Category = ["Laptops", "Macbook"],
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name =
                    "Laptop Gaming Acer Predator Helios Neo 14 PHN14-51-91WC cu procesor Intel® Core™ Ultra 9 185H pana la 5.1 GHz, 14.5 inch, WQXGA+, 165Hz, IPS, 32GB LPDDR5X, 1TB SSD, NVIDIA® GeForce RTX™ 4070 8GB GDDR6, No OS, Abyssal Black",
                Description =
                    "Oriunde va duce creativitatea, Predator Helios Neo 14 este instrumentul suprem pentru profesionistii versatili, creatorii pasionati si jucatorii competitivi. Faceti din fiecare mediu arena dvs., din fiecare cafenea un studio si din fiecare spatiu domeniul dvs.",
                ImageFile = "acer-predator-helios-14.jpg",
                Price = 10499.99M,
                Category = ["Laptops", "Gaming"],
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name =
                    "Monitor curbat gaming LED Xiaomi G34WQI, 34\" WQHD, HDMI, 180Hz, AMD FreeSync Premium, Certificare TuV Low Blue Light, Vesa, Negru",
                Description =
                    "Cu un raport de aspect 21:9, orizontul este cu 30% mai mare decat cel al ecranelor traditionale 16:9, iar rezolutia ultra clara WQHD ofera o calitate a imaginii si mai detaliata.",
                ImageFile = "xiaomi-gaming-monitor.jpg",
                Price = 1449.99M,
                Category = ["Monitors", "Gaming"],
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name =
                    "Laptop Dell Ultrabook XPS 9730, 17\", UHD+ Touch Display, cu Procesor Intel Core i9-13900H, 32GB Ram, 1TB SSD, NVIDIA GeForce RTX 4070, Windows 11 Pro, Platinum Silver",
                Description =
                    "Alimentati-va proiectele creative cu cel mai puternic laptop XPS de pana acum. Beneficiati de procesoare Intel® Core™ de pana la a 13-a generatie, grafica NVIDIA® GeForce RTX™ seria 40 si memorie DDR5, care are o viteza de ceas cu pana la 50% mai mare decat memoria DDR4.",
                ImageFile = "dell-xps.jpg",
                Price = 19999.99M,
                Category = ["Laptops"],
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name =
                    "Laptop Lenovo IdeaPad Slim 5 14AHP9 cu procesor AMD Ryzen™ 7 8845HS pana la 5.1GHz, 14\", WUXGA, OLED, DisplayHDR™ True Black 500, 32GB LPDDR5x, 1TB SSD, AMD Radeon™ 780M Graphics, No OS, Cloud Grey",
                Description =
                    "Performanta mai buna din punct de vedere termic.\nO inginerie termica imbunatatita faciliteaza cu usurinta cel mai greu multitasking. Elibereaza-ti potentialul si impinge-ti fluxul de lucru, datorita procesoarelor AMD Ryzen™ 8000-Series cu procesoare integrate care trec cu brio peste cele mai solicitante sarcini.",
                ImageFile = "lenovo-ideapad.jpg",
                Price = 4099.99M,
                Category = ["Laptops"],
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Telefon mobil Apple iPhone 16, 128GB, 5G, Ultramarine",
                Description =
                    "E iPhone 16, la fel ca cel de anul trecut. Just buy it, nu e mare diferenta! #apple",
                ImageFile = "iphone-16-ultramarine.jpg",
                Price = 4099.99M,
                Category = ["Smartphones", "iPhone"],
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Telefon mobil Apple iPhone 16 Pro, 128GB, 5G, Natural Titanium",
                Description =
                    "E iPhone 16 Pro, la fel ca cel de anul trecut. Just buy it, nu e mare diferenta! #apple",
                ImageFile = "iphone-16-pro.jpg",
                Price = 5999.99M,
                Category = ["Smartphones", "iPhone"],
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Telefon mobil Xiaomi MIX Flip, 12GB RAM, 512GB, 5G, Black",
                Description =
                    "Xiaomi MIX Flip stabileste un nou standard in telefoanele pliabile cu designul sau avansat si caracteristicile centrate pe utilizator, oferind utilizatorilor un mix perfect de durabilitate si stil. Prezentand un adevarat design emblematic atunci cand este deschis si transformandu-se intr-un telefon elegant si compact atunci cand este inchis, MIX Flip reprezinta evolutia cu succes a ecranului exterior al telefoanelor flip, depasind provocarile pentru a oferi o utilizare fara intreruperi direct pe ecranul exterior.",
                ImageFile = "xiaomi-mix-flip.jpg",
                Price = 6535.94M,
                Category = ["Smartphones", "Xiaomi"],
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name =
                    "Telefon mobil Samsung Galaxy S24 Ultra, Dual SIM, 12GB RAM, 512GB, 5G, Titanium Gray",
                Description =
                    "Bun venit in noua era AI. Cu Galaxy S24 Ultra poti descoperi o noua lume a creativitatii si productivitatii incepand cu cel mai important dispozitiv din viata ta. Telefonul tau.",
                ImageFile = "samsung-s24-ultra.jpg",
                Price = 5499.99M,
                Category = ["Smartphones", "Samsung"],
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name =
                    "Televizor SAMSUNG QLED 55Q80D, 138 cm, Smart, 4K Ultra HD, 100 Hz, Clasa F (Model 2024)",
                Description =
                    "Urmatorul nivel de realism si contrast 4K. Contrast ultrafin, pentru un negru profund si alb pur. Profunzime perceputa similar privirii umane.",
                ImageFile = "samsung-qled-tv.jpg",
                Price = 3723.88M,
                Category = ["TVs", "Samsung"],
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name =
                    "Televizor TCL LED 55P655, 139 cm, Smart Google TV, 4K Ultra HD, Clasa E (Model 2024)",
                Description =
                    "Urmatorul nivel de realism si contrast 4K. Contrast ultrafin, pentru un negru profund si alb pur. Profunzime perceputa similar privirii umane.",
                ImageFile = "tcl-led-tv.jpg",
                Price = 1499.99M,
                Category = ["TVs", "TCL"],
            },
        };
}
