namespace LibraVerse.Data.Seeding
{
    using Microsoft.AspNetCore.Identity;
    using System.Globalization;
    using LibraVerse.Data.Models.Articles;
    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Models.BookStores;
    using LibraVerse.Data.Models.Events;
    using LibraVerse.Data.Models.Roles;
    using static LibraVerse.Common.Constants.EntityValidationConstants.Article;
    using static LibraVerse.Common.Constants.EntityValidationConstants.BookStore;
    using static LibraVerse.Common.Constants.EntityValidationConstants.Event;
    using static LibraVerse.Common.Constants.CustomClaims;
    using static LibraVerse.Common.Custom;

    internal class DataSeed
    {
        //Ctor to seed the data
        public DataSeed()
        {
            SeedUsers();
            SeedPublisher();
            SeedBooks();
            SeedGenres();
            SeedBookReviews();
            SeedBookStores();
            SeedArticles();
            SeedArticleComments();
            SeedEvents();
        }

        //Seeded Users
        public ApplicationUser AdminUser { get; set; }
        public ApplicationUser PublisherUser { get; set; }
        public ApplicationUser GuestUser { get; set; }
        public ApplicationUser RandomUser1 { get; set; }
        public ApplicationUser RandomUser2 { get; set; }

        //Seeded Publisher - Roles
        public Publisher Publisher { get; set; }
        public Publisher PublisherAdmin { get; set; }

        // User Claims
        public IdentityUserClaim<string> AdminUserClaim { get; set; }
        public IdentityUserClaim<string> PublisherUserClaim { get; set; }
        public IdentityUserClaim<string> GuestUserClaim { get; set; }
        public IdentityUserClaim<string> RandomUser1Claim { get; set; }
        public IdentityUserClaim<string> RandomUser2Claim { get; set; }

        //The variety of Genres for the Books
        public Genre Adventure { get; set; }
        public Genre Art { get; set; }
        public Genre Autobiography { get; set; }
        public Genre Business { get; set; }
        public Genre Children { get; set; }
        public Genre ClassicLiterature { get; set; }
        public Genre Cooking { get; set; }
        public Genre Crime { get; set; }
        public Genre Drama { get; set; }
        public Genre Fantasy { get; set; }
        public Genre Fiction { get; set; }
        public Genre Historiography { get; set; }
        public Genre History { get; set; }
        public Genre Horror { get; set; }
        public Genre Humor { get; set; }
        public Genre Military { get; set; }
        public Genre Music { get; set; }
        public Genre Mythology { get; set; }
        public Genre Philosophy { get; set; }
        public Genre Poetry { get; set; }
        public Genre Political { get; set; }
        public Genre Romance { get; set; }
        public Genre Satire { get; set; }
        public Genre Science { get; set; }
        public Genre ScienceFiction { get; set; }
        public Genre ShortStories { get; set; }
        public Genre Thriller { get; set; }
     
        //Seeded Books
        public Book Book1 { get; set; }
        public Book Book2 { get; set; }
        public Book Book3 { get; set; }
        public Book Book4 { get; set; }
        public Book Book5 { get; set; }
        public Book Book6 { get; set; }
        public Book Book7 { get; set; }
        public Book Book8 { get; set; }
        public Book Book9 { get; set; }
        public Book Book10 { get; set; }
        public Book Book11 { get; set; }
        public Book Book12 { get; set; }
        public Book Book13 { get; set; }
        public Book Book14 { get; set; }
        public Book Book15 { get; set; }
        public Book Book16 { get; set; }
        public Book Book17 { get; set; }
        public Book Book18 { get; set; }
        public Book Book19 { get; set; }
        public Book Book20 { get; set; }
        public Book Book21 { get; set; }
        public Book Book22 { get; set; }
     
        //The reviews of a book
        public BookReview FirstReview { get; set; }
        public BookReview SecondReview { get; set; }
        public BookReview ThirdReview { get; set; }
        public BookReview FourthReview { get; set; }
        public BookReview FifthReview { get; set; }
        public BookReview SixthReview { get; set; }
        public BookReview SeventhReview { get; set; }
        public BookReview EighthReview { get; set; }
        public BookReview NinthReview { get; set; }
        public BookReview TenthReview { get; set; }
     
        //Book Stores
        public BookStore BookStore1 { get; set; }
        public BookStore BookStore2 { get; set; }
        public BookStore BookStore3 { get; set; }
        public BookStore BookStore4 { get; set; }
        public BookStore BookStore5 { get; set; }
        public BookStore BookStore6 { get; set; }
        public BookStore BookStore7 { get; set; }
        public BookStore BookStore8 { get; set; }
        public BookStore BookStore9 { get; set; }
        public BookStore BookStore10 { get; set; }
        public BookStore BookStore11 { get; set; }
        public BookStore BookStore12 { get; set; }
        public BookStore BookStore13 { get; set; }
        public BookStore BookStore14 { get; set; }
        public BookStore BookStore15 { get; set; }
     
        //Book Articles
        public Article Article1 { get; set; }
        public Article Article2 { get; set; }
        public Article Article3 { get; set; }
        public Article Article4 { get; set; }
        public Article Article5 { get; set; }
        public Article Article6 { get; set; }
        public Article Article7 { get; set; }
        public Article Article8 { get; set; }
        public Article Article9 { get; set; }
        public Article Article10 { get; set; }
     
        //Comments for the Article
        public ArticleComment Comment1;
        public ArticleComment Comment2;
        public ArticleComment Comment3;
        public ArticleComment Comment4;
        public ArticleComment Comment5;
        public ArticleComment Comment6;
        public ArticleComment Comment7;
        public ArticleComment Comment8;
        public ArticleComment Comment9;
        public ArticleComment Comment10;
     
        //Events
        public Event EventOne { get; set; }
        public Event EventTwo { get; set; }
        public Event EventThree { get; set; }
        public Event EventFour { get; set; }
        public Event EventFive { get; set; }
        public Event EventSix { get; set; }
        public Event EventSeven { get; set; }
        public Event EventEight { get; set; }
        public Event EventNine { get; set; }
        public Event EventTen { get; set; }
        public Event EventEleven { get; set; }
    

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            AdminUser = new ApplicationUser()
            {
                Id = "8482124a-1681-41b9-81bd-83e20223d345",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                FirstName = "Klinchoni",
                LastName = "Boss",
            };

            AdminUserClaim = new IdentityUserClaim<string>()
            {
                Id = 1,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Klinchoni Boss",
                UserId = "8482124a-1681-41b9-81bd-83e20223d345"
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "Klinch_27");


            PublisherUser = new ApplicationUser()
            {
                Id = "9abf1366-cadf-4837-bc30-1b77599ff9cb",
                UserName = "nasko_publisher@gmail.com",
                NormalizedUserName = "NASKO_PUBLISHER@GMAIL.COM",
                Email = "nasko_publisher@gmail.com",
                NormalizedEmail = "NASKO_PUBLISHER@GMAIL.COM",
                FirstName = "Nasko",
                LastName = "Publisher",
            };

            PublisherUserClaim = new IdentityUserClaim<string>()
            {
                Id = 2,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Nasko Publisher",
                UserId = "9abf1366-cadf-4837-bc30-1b77599ff9cb"
            };

            PublisherUser.PasswordHash = hasher.HashPassword(PublisherUser, "Nasko_01");


            GuestUser = new ApplicationUser()
            {
                Id = "7c8eb412-65a9-4050-8c67-62278f3af93c",
                UserName = "petya_guest@gmail.com",
                NormalizedUserName = "PETYA_GUEST@GMAIL.COM",
                Email = "petya_guest@gmail.com",
                NormalizedEmail = "PETYA_GUEST@GMAIL.COM",
                FirstName = "Petya",
                LastName = "Guesta",
            };

            GuestUserClaim = new IdentityUserClaim<string>()
            {
                Id = 3,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Petya Guesta",
                UserId = "7c8eb412-65a9-4050-8c67-62278f3af93c"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "Petya_08");

            RandomUser1 = new ApplicationUser()
            {
                Id = "b4a1311e-dff4-4c3a-9cf7-b794557bdf80",
                UserName = "ivankl@gmail.com",
                NormalizedUserName = "IVANKL@GMAIL.COM",
                Email = "ivankl@gmail.com",
                NormalizedEmail = "IVANKL@GMAIL.COM",
                FirstName = "Ivan",
                LastName = "Best",
            };

            RandomUser1Claim = new IdentityUserClaim<string>()
            {
                Id = 4,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Ivan Best",
                UserId = "b4a1311e-dff4-4c3a-9cf7-b794557bdf80"
            };

            RandomUser1.PasswordHash = hasher.HashPassword(GuestUser, "Ivan_24");

            RandomUser2 = new ApplicationUser()
            {
                Id = "c4fbe2f71-126f-46c3-af99-8dc035eac772",
                UserName = "yonni@gmail.com",
                NormalizedUserName = "YONNI@GMAIL.COM",
                Email = "yonni@gmail.com",
                NormalizedEmail = "YONNI@GMAIL.COM",
                FirstName  = "Yonni",
                LastName = "Bonboni",
            };

            RandomUser2Claim = new IdentityUserClaim<string>()
            {
                Id = 5,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Yonni Bonboni",
                UserId = "c4fbe2f71-126f-46c3-af99-8dc035eac772"
            };

            RandomUser2.PasswordHash = hasher.HashPassword(GuestUser, "yonni_05");
        }

        private void SeedPublisher()
        {
            Publisher = new Publisher()
            {
                Id = 1,
                UserId = PublisherUser.Id
            };

            PublisherAdmin = new Publisher()
            {
                Id = 2,
                UserId = AdminUser.Id
            };
        } 

        private void SeedGenres()
        {
            Adventure = new Genre()
            {
                Id = 1,
                Name = "Приключенски"
            };

            Art = new Genre()
            {
                Id = 2,
                Name = "Изкуство"
            };

            Autobiography = new Genre()
            {
                Id = 3,
                Name = "Автобиография"
            };

            Business = new Genre()
            {
                Id = 4,
                Name = "Бизнес"
            };

            Children = new Genre()
            {
                Id = 5,
                Name = "Детска литература"
            };

            ClassicLiterature = new Genre()
            {
                Id = 6,
                Name = "Класическа литература"
            };

            Cooking = new Genre()
            {
                Id = 7,
                Name = "Кулинарни"
            };

            Crime = new Genre()
            {
                Id = 8,
                Name = "Криминален"
            };

            Drama = new Genre()
            {
                Id = 9,
                Name = "Драма"
            };

            Fantasy = new Genre()
            {
                Id = 10,
                Name = "Фентъзи"
            };

            Fiction = new Genre()
            {
                Id = 11,
                Name = "Художествена литература"
            };

            Historiography = new Genre()
            {
                Id = 12,
                Name = "Историография"
            };

            History = new Genre()
            {
                Id = 13,
                Name = "История"
            };

            Horror = new Genre()
            {
                Id = 14,
                Name = "Хорър"
            };

            Humor = new Genre()
            {
                Id = 15,
                Name = "Хумор"
            };

            Military = new Genre()
            {
                Id = 16,
                Name = "Военни"
            };

            Music = new Genre()
            {
                Id = 17,
                Name = "Музика"
            };

            Mythology = new Genre()
            {
                Id = 18,
                Name = "Митология"
            };

            Philosophy = new Genre()
            {
                Id = 19,
                Name = "Философия"
            };

            Poetry = new Genre()
            {
                Id = 20,
                Name = "Поезия"
            };

            Political = new Genre()
            {
                Id = 21,
                Name = "Политическа литература"
            };

            Romance = new Genre()
            {
                Id = 22,
                Name = "Любовен"
            };

            Satire = new Genre()
            {
                Id = 23,
                Name = "Сатира"
            };

            Science = new Genre()
            {
                Id = 24,
                Name = "Наука"
            };

            ScienceFiction = new Genre()
            {
                Id = 25,
                Name = "Научна фантастика"
            };

            ShortStories = new Genre()
            {
                Id = 26,
                Name = "Разкази"
            };

            Thriller = new Genre()
            {
                Id = 27,
                Name = "Трилър"
            };
        }
        
        private void SeedBooks()
        {
            Book1 = new Book()
            {
                Id = 1,
                Title = "Дивото зове",
                Author = "Джек Лондон",
                GenreId = 1,
                Description = "Разказва се за южняшкото куче Бък, което попада сред дивия север. След много битки с Шпиц, теглене на тежки пощенски шейни, неприятности с алчни хора, Бък открива Джон Тортън. Бък му остава верен до гроб, но дивите му истинкти надделяват и той често изчезва от лагера. Един ден той се връща от лов и вижда господаря си убит от ихатите. По-късно той се присъединява към глутница вълци. ",
                Pages = 128,
                YearPublished = 1903,
                Price = 5.00m,
                ImageUrl = "https://i2.helikon.bg/products/4956/05/54956/0658229_b.jpg?t=1732090822",
            };

            Book2 = new Book()
            {
                Id = 2,
                Title = "История славянобългарска",
                Author = "Паисий Хилендарски",
                GenreId = 12,
                Description = "Има една книга, която винаги ще намери място в българския дом. На вашето внимание представяме луксозно фототипно издание на една от най-ценните родни творби – „История славянобългарска“ от Паисий Хилендарски. Достойнството на това издание е преводът на новобългарски. Той следва ред по ред Котленския препис на Софроний Врачански, представен чрез факсимилета на всяка страница. По този начин читателят може да вникне пълноценно в историческото повествование, четейки и сравнявайки написаното от хилендарския монах. Нещо повече  – използван е официално одобреният превод от Зографската света обител, дело на изтъкнатия преподавател в катедра „Кирилометодиевистика“ в Софийския университет ас. д-р Димитър Пеев. Съвместно с проф. Александър Николов, той е автор и на научния коментар. Изданието се реализира в сътрудничество със Зографската света обител и Националната библиотека Св. св. Кирил и Методий.",
                Pages = 240,
                YearPublished = 1762,
                Price = 30.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/i/s/istoria-slavianobylgarska.jpg",
            };

            Book3 = new Book()
            {
                Id = 3,
                Title = "Около света за осемдесет дни",
                Author = "Жул Верн",
                GenreId = 1,
                Description = "В един привидно нормален ден в ексклузивния клуб Reform, Филиас Фог, джентълмен с голямо богатство и взискателни вкусове, прави изключителен залог от £20 000; той ще извърши невъзможен подвиг и ще обиколи земното кълбо само за осемдесет дни. Придружен само от новия си френски камериер, упорития Паспарту, той тръгва на вълнуващо пътешествие. Следват приключения, хаос и романтика, докато Фог и Паспарту използват новата сила на парата, за да избягат от непрекъснато увеличаващите се врагове и да изпреварят времето.",
                Pages = 280,
                YearPublished = 1873,
                Price = 25.90m,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/86/Verne_Tour_du_Monde.jpg/330px-Verne_Tour_du_Monde.jpg",
            };

            Book4 = new Book()
            {
                Id = 4,
                Title = "История на Херодот",
                Author = "Херодот",
                GenreId = 13,
                Description = "Уважаеми читателю,Историята на Херодот е забележително и увлекателно описание на персийските войни на царете Кир, Дарий, Камбис и Ксеркс, син на Дарий. С големи подробности е описана войната на персите с елинските градове държави, водена от цар Ксеркс, която започва през 499 г. пр.н.е. и продължава до 449 г. пр.н.е. Тази история е написана под формата на художествен разказ, наситен с исторически сведения, предания, легенди, преплетени с вярванията в системата от богове на елини и перси. Особен интерес за българската история представляват сведенията за тракийските народи, дадени във връзка с различни събития. За изучаващите историята на Европа и в частност на България тази книга е задължително четиво. Херодот е роден около 484 г. пр.н.е. в Халикарнас, в областта Кария в Мала Азия, по негово време градът е васал на Персия, и умира около 425 г. пр.н.е., така че той е съвременник на войната на Ксеркс, което прави сведенията му неоценимо полезни. Изучавайки този обемист литературно-исторически труд и огромното количество дискусии върху него, човек неминуемо се смущава от това, че Херодот бива наричан първи историк, бащата на историята и т.н. Не е възможно да се появи по онова време такъв забележителен труд без по негово време да е имало множество предшественици и съвременници, писали по подобен начин, но просто неумолимото време е съхранило за нас само този труд. През 1888 г. Ф. Г. Мищенко превежда на руски Историята на Херодот разделяйки я на два тома. Превод от старогръцки на български на избрани пасажи се появяват в Извори на старата история на Тракия и Македония, София, 1949 г., превод на Г. Кацаров и Б. Геров, Извори за историята на Тракия и траките, том 1, БАН, София, 1981, превод Иван Венедиков и Д. Бояджиев, а също и в превода на Д. Гетов, в Херодот, Исторически новели, Народна култура, София, 1982.Пълен превод на Историята на Херодот на български публикува Петър Ангелов Димитров: през 1986 г. първи том, а през 1990 г. втори том, използвайки английско и френско издание на старогръцкия текст на Историята. През 1972 г. Г. А. Стратановски прави нов превод от старогръцки. Този превод на руски е публикуван в интернет през 2008 година. Настоящето издание е превод от руски, като в случаи на съмнения е правена справка с превода на Димитров. Прави впечатление, че смисълът на всички пасажи е идентичен, но има някои разлики в изписването на персийските и елински имена. Д-р Николай Иванов Колев, 15.8.2024 - Херцогенаурах, Германия",
                Pages = 810,
                YearPublished = 1888,
                Price = 50.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/h/e/herodot-istoria.jpg",
            };

            Book5 = new Book()
            {
                Id = 5,
                Title = "История на изкуството",
                Author = "Николай Райнов",
                GenreId = 2,
                Description = "„История на изкуството“ на Николай Райнов е грандиозен, несравним по своята всеобхватност и дълбочина труд, оказал огромно влияние върху развитието на българската култура. Блестящ ерудит, белетрист и поет, график и декоратор, историк и стилист, изследовател и философ, авторът проследява промените през различните епохи – от най-древните времена до началото на XX век – и изразяването на човешкия дух чрез изкуството.",
                Pages = 808,
                YearPublished = 2024,
                Price = 98.00m,
                ImageUrl = "https://i2.helikon.bg/products/6357/24/246357/246357_b.jpg?t=1732093233",
            };

            Book6 = new Book()
            {
                Id = 6,
                Title = "Пипи Дългото чорапче",
                Author = "Астрид Линдгрен",
                GenreId = 5,
                Description = "Астрид Линдгрен (1907-2002) е написала три романа за червенокосата Пипи: \"Пипи Дългото чорапче\" (1945), \"Пипи се качва на кораба\" (1946) и \"Пипи в южните морета\" (1948). През 1968 г. на български език се появява книга със заглавие \"Пипи Дългото чорапче\". В нея, както и в по-следващите й издания, са включени част от разказите за Пипи от трите романа. И по-точно - 24 от общо 32 глави. Така близо една трета от историите за червенокосото момиче остават непознати за нашия читател. В настоящото издание е събрана цялата трилогия за Пипи. За първи път на български език се публикуват главите: - Пипи се бори с огнена стихия - Пипи още живее във Вила Вилекула - Пипи пише писмо и пак тръгва на училище - но за малко... - И Пипи отива на училищен излет - Пипи на панаир - Пипи си остава във Вила Вилекула - Пипи разведрява леля Лаура",
                Pages = 352,
                YearPublished = 2017,
                Price = 10.90m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/f/i/file_267_80.jpg",
            };

            Book7 = new Book()
            {
                Id = 7,
                Title = "Класика за деца - Приключенията на Том Сойер",
                Author = "Марк Твен",
                GenreId = 5,
                Description = "За Том Сойер, Хъкълбери Фин и Беки животът край Мисисипи е непрекъснат низ от приключения, истински опасности и дори скрито съкровище, Да ги проследим заедно, водени от изкусния разказвач Марк Твен.",
                Pages = 92,
                YearPublished = 2024,
                Price = 19.90m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/9/7/9786192440992.jpg",
            };

            Book8 = new Book()
            {
                Id = 8,
                Title = "Фондация",
                Author = "Айзък Азимов",
                GenreId = 24,
                Description = "Един от най-великите научнофантастични романи, в който се разказва за разпадането на Галактическата империя и опитите на Хари Селдън да съхрани знанията на човечеството чрез създаването на Фондацията.",
                Pages = 296,
                YearPublished = 1951,
                Price = 18.90m,
                ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/k/o/33e0e63922387923bfa42e3bec9f7e2c/kolektsiya-fondatsiya-30.jpg",
            };

            Book9 = new Book()
            {
                Id = 9,
                Title = "Дневникът на Ане Франк",
                Author = "Ане Франк",
                GenreId = 9,
                Description = "Дневникът на едно младо момиче, криещо се от нацистите в Амстердам. Този запис на надеждите, страховете и мислите ѝ е станал символ на човешката издръжливост.",
                Pages = 340,
                YearPublished = 1947,
                Price = 12.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/32bb0748c82325b02c55df3c2a9a9856/a/n/ane-frank-zadnata-kyshta-ciela-9789542827214.jpg",
            };

            Book10 = new Book()
            {
                Id = 10,
                Title = "Дон Кихот",
                Author = "Мигел де Сервантес",
                GenreId = 6,
                Description = "Историята на рицаря от Ла Манча, който тръгва на приключение със своя оръженосец Санчо Панса. Сатиричен разказ за идеалите и реалността.",
                Pages = 1072,
                YearPublished = 1605,
                Price = 22.90m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/7/9/79588.jpeg",
            };

            Book11 = new Book()
            {
                Id = 11,
                Title = "Летният принц",
                Author = "Алая Доун Джонсън",
                GenreId = 10,
                Description = "След като Земята е сполетяна от бедствия и разруха, оцелелите в Бразилия построяват града пирамида Палмареш Треш, в който жените управляват и периодично се избира Крал само за една година. Той трябва да посочи следващата Кралица, преди да бъде принесен в жертва. Непокорната и талантлива Джун Коста е запленена от последните избори и с всички средства подкрепя Анки, красиво момче от най-долното ниво на града. След като той печели, Джун и най-добрият й приятел Жил попадат в света на новия Крал. Енки е ярка и бързо изгряваща звезда, чиято светлина отваря очите на Джун за сериозните проблеми на Палмареш Треш. Двамата създават произведения на изкуството, които градът никога няма да забрави, и разпалват искрата на недоволството срещу властта. Под звуците на самба всички се впускат в танц на живот и смърт, в който залогът е бъдещето.",
                Pages = 336,
                YearPublished = 2014,
                Price = 15.00m,
                ImageUrl = "https://knizhen-pazar.net/books/088/8809/880919.jpg?size=22461",
            };

            Book12 = new Book()
            {
                Id = 12,
                Title = "Преследването на Аделайн - книга 1",
                Author = "Х. Д. Карлтън",
                GenreId = 22,
                Description = "Аделайн се настанява в някога внушителното, но сега западнало имение „Парсънс“, което е наследила от баба си. Успешна писателка, надарена с богато въображение, тя се чувства съвсем на място сред готическата атмосфера на къщата и тайните, скътани във всяка паяжина. А когато случайно се натъква на дневника на прабаба си Джиджи, намерена мъртва в къщата преди повече от шейсет години, разбира, че може би е открила и ключа към мистерията кой я е убил.\r\n\r\nНо по-голямата загадка сякаш е кой е тайнственият непознат, който наблюдава къщата ѝ, преследва мъжете, осмелили се да я погледнат, и оставя червени рози в спалнята ѝ.\r\n\r\nИ защо, вместо да потърси помощ от полицията, Аделайн се наслаждава да го предизвиква?",
                Pages = 624,
                YearPublished = 2024,
                Price = 30.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/p/u/purva-adeline-latest.jpg",
            };

            Book13 = new Book()
            {
                Id = 13,
                Title = "Безсилна",
                Author = "Лорън Робъртс",
                GenreId = 10,
                Description = "Ловец. Жертва. Обречени един за друг.\r\n\r\nЕдинствено необикновените имат място в кралство Илиа…\r\n\r\nОт десетилетия Елитните притежават своите сили, придобити благодарение на Чумата, докато Обикновените са изолирани от обществото и прокуждани от кралството.\r\n\r\nНикой не е изпитал това на гърба си по-добре от Пейдин Грей, Обикновена, която се представя за Ясновидец, за да се слее с тълпата от Елитни. Когато Пейдин, без да подозира, спасява живота на един от принцовете на Илиа, тя е включена против волята си в Изпитанията на Прочистването – жестока, кървава надпревара, превърната в демонстрация на силата на Елитните.\r\n\r\nАко противниците ѝ в Изпитанията не я убият, това ще направи принцът, с чувствата си към когото Пейдин напразно се опитва да се бори… А той непременно ще я убие, ако разбере, че тя е Обикновена.\r\n\r\nПотопете се в първия том от епичната фентъзи трилогия „Безсилна“ на Лорън Робъртс, изпълнена с приключения и романтика, която покори целия свят…\r\n\r\n",
                Pages = 528,
                YearPublished = 2024,
                Price = 25.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/_/-/_-__478.jpg",
            };

            Book14 = new Book()
            {
                Id = 14,
                Title = "Измерения на болката",
                Author = "Димитър Цолов",
                GenreId = 14,
                Description = "В сборника с ужаси от български автори \"Измерения на болката\" са включени разкази от:\r\n\r\nАлекс Цонков, Анна Гюрова, Димитър Маргаритов, Димитър Цолов, Елена Зелена Бърдарова, Елена Павлова, Мария Пеева, Мария Раднева, Милен Димитров, Нина Митева, Ралица Пейкова, Явор Цанев. Съставител и редактор е Милен Димитров. Разказите са маркирани с тагове за улеснение на читателя.\r\n\r\n...Историите се носят през пространство-времето, като преплитат в себе си минало, настояще и бъдеще, фентъзи, фантастика, паралелни светове и реализъм, а страхът в тях се проявява освен във фантастичното и непонятното, така и в чисто човешкото битие, където разноликите герои влизат в схватка както с външни сили, така и със самите себе си...",
                Pages = 304,
                YearPublished = 2024,
                Price = 20.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/_/-/_-_-_9786197771237_-_-_ciela.jpg",
            };

            Book15 = new Book()
            {
                Id = 15,
                Title = "Най-великата игра",
                Author = "Дженифър Лин Барнс",
                GenreId = 27,
                Description = "Седем билета. Остров сред океана. Шанс, който се пада един път в живота.\r\n\r\nДобре дошли в „Най-великата игра“, ослепителното, променящо животи състезание, организирано от Ейвъри Грамс и четиримата скандално известни братя Хоторн. Създадена, за да предложи шанс за слава и богатство, тазгодишната игра е ограничена до седем късметлии.\r\n\r\nЛИЙРА е преследвана от смъртта на баща си и тайните, които е оставил след себе си. Тя си казва, че се е включила в състезанието заради наградата, а не, за да получи отговори относно участието на семейство Хоторн в трагичния край на баща ѝ и категорично не, за да се изправи срещу вбесяващия, загадъчен Грейсън Хоторн, когото вече е отхвърлила веднъж\r\n\r\nСрещу Лийра се изправят ДЖИДЖИ, полусестрата на Грейсън и истински слънчев лъч, решена да докаже, че е способна на повече, отколкото останалите смятат, и РОХАН, който има много малко морални задръжки, опасни и еклектични умения и никакво бъдеще - освен ако не спечели играта.\r\n\r\nЗахвърлени на частен остров, сред лукс и загадки за разрешаване, Лийра, Джиджи и Рохан трябва да направят всичко, на което са способни, за да надделеят един над друг, да се справят с останалите си страховити съперници и да победят в игра, която само най-острите умове биха могли да спечелят. Прехвърчат искри, предизвикателства тласкат участниците до предела на силите им, а всеки един от тях пази тайни, които няма как да останат погребани завинаги.\r\n\r\n",
                Pages = 368,
                YearPublished = 2024,
                Price = 19.90m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/g/r/grandestgame_bg_cv_front1728926839.7707.jpg.jpeg",
            };

            Book16 = new Book()
            {
                Id = 16,
                Title = "Счетоводство и финанси за нефинансови мениджъри",
                Author = "Петър Петров",
                GenreId = 4,
                Description = "Книгата \"Счетоводство и финанси за нефинансови мени¬джъри\" ви предоставя лесен начин за разбиране на иначе сложната материя, свързана със счетоводството и финансите – до минималното ниво, което е необходимо на всеки нефинансов мениджър. Книгата може да бъде полезна и за изучаващите финанси, финансово и управленско счетовод¬ство, които срещат практически трудности в разбирането на тази материя. Книгата е структурирана в седем глави, представени под формата на уроци, запознаващи читателите с основните аспекти на активите, пасивите, приходите и разходите – както по отношение на тяхната същност и счетоводно отчитане, така и по отношение на икономическата и финансовата трактовка на свързаните с тях показатели.\r\nДнес новините изобилстват от примери за това до какво може да доведе липсата на минимални познания по счетоводство и финанси – кредитиране в швейцарски франкове при доходи в левове, договаряне на нереално високи преференциални лихви и др. За всички, които не желаят да бъдат част от тези новини, книгата \"Счетоводство и финанси за нефинансови мениджъри\" ще бъде учебното помагало, което съчетава хармонично необходимия минимум от теория на счетоводството и финансите със задължителния практикум за лесно усвояване на такива знания и неусетното им превръщане в умения.",
                Pages = 220,
                YearPublished = 2016,
                Price = 20.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/1/9/198677_b.jpg",
            };

            Book17 = new Book()
            {
                Id = 17,
                Title = "Тайните на трафика",
                Author = "Зорница Русева",
                GenreId = 4,
                Description = "В тази книга Ръсел Брънсън, съосновател и изпълнителен директор на мултимилионната компания ClickFunnels, разкрива класическите основополагащи техники за директен маркетинг, които ще ви сложат на челно място сред успешните бизнес компании, ще ви посочат възможности, каквито мнозина пропускат да забележат, и ще ви обучат как да се отличавате от всички останали играчи.\r\n\r\nС инструкции стъпка по стъпка Брънсън ще ви научи да управлявате множество трафик източници, както и да прилагате пазарно проверени стратегии, за да:\r\n\r\nидентифицирате вашите мечтани клиенти;\r\nоткривате къде те вече се събират онлайн;\r\nсъздадете собствена платформа за публикуване;\r\nсъставите собствени списъци за разпространение.",
                Pages = 344,
                YearPublished = 2024,
                Price = 29.99m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/_/-/_-__453.jpg",
            };

            Book18 = new Book()
            {
                Id = 18,
                Title = "Истината за последните години от живота на Майкъл Джексън",
                Author = "Иън Хaлпърин",
                GenreId = 17,
                Description = "На 24 декември 2008 г. световните медии публикуват скандалното заявление на разследващия журналист Иън Хaлпърин, че на Майкъл Джексън му остава половин година живот. Официалният говорител на звездата определя твърдението като „пълна измислица”. Шест месеца и един ден по-късно светът е разтърсен от новината за смъртта на Краля на попа.",
                Pages = 376,
                YearPublished = 2009,
                Price = 14.95m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/1/0/104198.jpeg",
            };

            Book19 = new Book()
            {
                Id = 19,
                Title = "Българите на Волга",
                Author = "Георги Владимиров",
                GenreId = 13,
                Description = "Книгата „Българите на Волга“ е продукт на дългогодишните проучвания на д-р Г. Владимиров върху историята и културата на българите от заселването им в земите на Средна Волга през VIII в. до унищожаването на техния културен модел през втората половина на XVI в. На базата на писмени извори, археологически, етнографски и антропологически данни изданието проследява политическата и стопанската история, бита, материалната и духовната култура на населението на Волжка България, Златната орда и Казанското ханство.\r\n\r\n",
                Pages = 248,
                YearPublished = 2024,
                Price = 20.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/b/u/bulgarite_na_volga-hrm.jpg",
            };

            Book20 = new Book()
            {
                Id = 20,
                Title = "Манипулирайте, но правилно - Осемте закона на въздействието върху хората",
                Author = "Йозеф Киршнер",
                GenreId = 19,
                Description = "Манипулативната игра има свои правила и всеки, който иска да осъществи себе си, трябва да ги овладее. Книгата е предизвикателство за всички, които не искат да бъдат пасивни жертви на манипулацията, а съзнателно и целенасочено да се утвърждават във всекидневното общуване. Всеки има шанс да стане господар на съдбата си стига само да поеме инициативата.\r\n\r\n",
                Pages = 236,
                YearPublished = 1995,
                Price = 18.00m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/m/a/manipuliraite-no-pravilno-josef-kirshner-kibea.jpg",
            };

            Book21 = new Book()
            {
                Id = 21,
                Title = "500 рецепти за бебета и малки деца",
                Author = "Бевърли Глок",
                GenreId = 7,
                Description = "Епичен роман за руското общество по време на Наполеоновите войни.",
                Pages = 288,
                YearPublished = 2024,
                Price = 22.90m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/5/0/500__7.jpg",
            };

            Book22 = new Book()
            {
                Id = 22,
                Title = "Смях от Британските острови",
                Author = "Пергамент Прес",
                GenreId = 15,
                Description = "В този сборник си дават среща изтънченият и понякога циничен хумор на англичаните, закачливият, дяволит и жизнерадостен хумор на шотландците, пиперливият и прям хумор на ирландците и накрая неподправеният и добродушен хумор на уелсците.",
                Pages = 320,
                YearPublished = 2013,
                Price = 19.95m,
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/f/i/file_577_211.jpg",
            };
        }
        
        private void SeedBookReviews()
        {
            FirstReview = new BookReview()
            {
                Id = 1,
                Title = "Незабравимо приключение!",
                Description = "Книгата ме потопи в суровия и вдъхновяващ свят на дивата природа! Лондон създава невероятно усещане за живот на ръба между цивилизацията и природата, като главният герой Бък става символ на оцеляването и личната еволюция. Препоръчвам на всички любители на приключенски романи и природата.",
                Rate = 10,
                BookId = 1,
                UserId = "9abf1366-cadf-4837-bc30-1b77599ff9cb"
            };

            SecondReview = new BookReview()
            {
                Id = 2,
                Title = "Уникална по рода си книга!",
                Description = "Току-що приключих с четенето на „Пипи Дългото чорапче“ и не мога да не споделя колко ми хареса! Пипи е една от най-забавните и нестандартни героини, които съм срещала. Нейният уникален характер, свобода на духа и хумор я правят незабравима. Освен това, животът й е изпълнен с толкова невероятни приключения, че няма как да не се увлечеш по нея! Всеки момент с нея е забавен и лек, но същевременно носи и уроци за приятелството, смелостта и стойността на свободата. Книгата е за всички възрасти, но аз лично не можех да спра да се смея на някои от нейните лудории и смели решения. Препоръчвам на всеки, който търси книга, която да му донесе радост и приключения.",
                Rate = 10,
                BookId = 6,
                UserId = "c4fbe2f71-126f-46c3-af99-8dc035eac772"
            };

            ThirdReview = new BookReview()
            {
                Id = 3,
                Title = "Велико произведение, но не за всеки вкус.",
                Description = "„Дон Кихот“ е произведение, което ни представя уникална смесица от хумор и трагедия, но не мога да кажа, че веднага ме завладя. Образът на Дон Кихот е интересен, но понякога твърде странен за моите предпочитания. Тази книга изисква внимание и размисъл, но може да не е за всеки читател.",
                Rate = 5,
                BookId = 10,
                UserId = "b4a1311e-dff4-4c3a-9cf7-b794557bdf80"
            };

            FourthReview = new BookReview()
            {
                Id = 4,
                Title = "Не, не и НЕ!",
                Description = "Честно казано, не успях да се потопя в света на Фондацията и ми беше трудно да се свържа с героите. Смятах, че научната фантастика ще е по-ангажираща, но този роман не успя да задържи вниманието ми. Някои пасажи бяха прекалено дълги и скучни. За съжаление, не беше моето четиво.",
                Rate = 1,
                BookId = 8,
                UserId = "7c8eb412-65a9-4050-8c67-62278f3af93c"
            };

            FifthReview = new BookReview()
            {
                Id = 5,
                Title = "Задължително четиво за всеки българин!",
                Description = "Книгата ме изуми с богатството на информация и историческа достоверност. Историята на българския народ, разказана през погледа на Паисий Хилендарски, е не само задълбочена, но и изпълнена със страст и гордост. През всяка страница усещах любовта на автора към Родината и силата на народния дух. Всеки българин трябва да се запознае с това произведение, за да разбере по-добре своето минало и корените на своята идентичност. Препоръчвам я на всички, които искат да се потопят в българската история и да я преживеят отново!",
                Rate = 10,
                BookId = 2,
                UserId = "b4a1311e-dff4-4c3a-9cf7-b794557bdf80"
            };

            SixthReview = new BookReview()
            {
                Id = 6,
                Title = "Забавна, но не толкова вълнуваща",
                Description = "Книгата беше приятна за четене, но не мога да кажа, че ме впечатли. Историята на Пъжи и неговото пътуване около света е интересна, но не беше толкова динамична, колкото очаквах. Спокойният стил на писане на Жул Верн не успя да ме погълне напълно и се почувствах леко разочарован. Все пак, въпреки че не ми се стори изключителна, не мога да отрека, че е увлекателна и доста класическа приключенска история. Препоръчвам я на тези, които обичат по-лежерни приключения.",
                Rate = 6,
                BookId = 3,
                UserId = "9abf1366-cadf-4837-bc30-1b77599ff9cb"
            };

            SeventhReview = new BookReview()
            {
                Id = 7,
                Title = "Велико произведение, което ще ми остане в сърцето!",
                Description = "История на Херодот е книга, която не просто ме възхити, а напълно промени възприятията ми за историята и човешката цивилизация. За първи път се срещнах с толкова обширно и задълбочено изложение на събития, които преди да прочета, бяха просто мъгляви елементи от учебниците. Херодот е истински майстор на разказа, който умее да потопи читателя в света на древността. Книгата не е просто хронология, тя е пътуване през различни култури и народи, които са оформили съвременната история, както я познаваме. Всеки ред беше наситен с толкова много информация, че ми се искаше да го четем по-бавно, за да усвоя всички детайли. Горещо препоръчвам на всеки, който обича историята и е готов да се потопи в древността.",
                Rate = 10,
                BookId = 4,
                UserId = "7c8eb412-65a9-4050-8c67-62278f3af93c"
            };

            EighthReview = new BookReview()
            {
                Id = 8,
                Title = "Не оправда очакванията ми",
                Description = "Очаквах много повече от тази книга, но за съжаление тя не успя да ме впечатли. Сюжетът ми се стори изключително плосък, а стилът на писане - сух и скучен. За такава важна тема, като историята на изкуството, се изисква много по-задълбочено и ангажиращо представяне. Може би за някои хора тя ще е полезна, но за мен беше разочароваща и не ме вдъхнови да се запозная по-задълбочено с изкуството.",
                Rate = 3,
                BookId = 5,
                UserId = "9abf1366-cadf-4837-bc30-1b77599ff9cb"
            };

            NinthReview = new BookReview()
            {
                Id = 9,
                Title = "Силно въздействаща книга!",
                Description = "„Дневникът на Ане Франк“ е изключителен разказ за живота на едно младо момиче, което преживява нечовешки изпитания през Втората световна война. Нейният дневник ме докосна дълбоко, като показва смелостта и надеждата, въпреки ужасите на времето. Писанията й са искрени и пълни с емоция. Историята е толкова лична, но същевременно универсална, и оставя трайни следи в съзнанието. Препоръчвам на всички да я прочетат, защото тя е част от световното културно наследство.",
                Rate = 10,
                BookId = 9,
                UserId = "7c8eb412-65a9-4050-8c67-62278f3af93c"
            };

            TenthReview = new BookReview()
            {
                Id = 10,
                Title = "Забавна, но не чак толкова впечатляваща",
                Description = "„Приключенията на Том Сойер“ определено има своите забавни моменти и увлекателни ситуации, но като цяло не се оказа толкова вълнуваща, колкото очаквах. Има забавни сцени, които със сигурност биха заинтригували по-младите читатели, но за мен книгата не предложи нещо изключително в повествованието. Може би е по-интересна за по-млади аудитории, които ще оценят приключенията на Том и Хък ФInn, но за мен остана леко повърхностна.",
                Rate = 6,
                BookId = 7,
                UserId = "c4fbe2f71-126f-46c3-af99-8dc035eac772"
            };
        }

        private void SeedBookStores()
        {
            BookStore1 = new BookStore()
            {
                Id = 1,
                Name = "Ciela - София",
                Location = "бул. Цар Освободител 22, 1000 София, България",
                ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipOEsGmlKTuS7Nog7kX9vQfcWBwxw5tyAloSvkMz=s1360-w1360-h1020-rw",
                OpeningTime = DateTime.ParseExact("08:30", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("20:30", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+359 88 651 1944",
            };

            BookStore2 = new BookStore()
            {
                Id = 2,
                Name = "Helikon - Бургас",
                Location = "Бургас Център, ул. „Тройката“ 4, 8000 Бургас",
                ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipPs7hpPMTum4GJ7Iny4YCZLVYiZeh0ljXxykOiQ=s1360-w1360-h1020-rw",
                OpeningTime = DateTime.ParseExact("09:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("19:30", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+359 56 800 620",
            };

            BookStore3 = new BookStore()
            {
                Id = 3,
                Name = "Orange - Paradise Center",
                Location = "Хладилника, бул. „Черни връх“ 100, 1407 София",
                ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipPQqWlmrzQ2BrBpRpyshwBFFeLofJKUlGeCIDf3=s1360-w1360-h1020",
                OpeningTime = DateTime.ParseExact("10:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("22:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+359 88 403 2576",
            };

            BookStore4 = new BookStore()
            {
                Id = 4,
                Name = "Helikon - Пловдив Център",
                Location = "ул. „Княз Александър I-ви“ 29, 4000 Пловдив",
                ImageUrl = "https://cdn.oink.bg/gallery/23010/05adf581-0397-4f92-a9fa-65a087cd918f_large.webp",
                OpeningTime = DateTime.ParseExact("09:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("20:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+359 32 207 621",
            };

            BookStore5 = new BookStore()
            {
                Id = 5,
                Name = "Дъга - Разлог",
                Location = "ул. „Шейново“ 6, 2760 Разлог",
                ImageUrl = "https://web-portalbg.com/media/data/official_reskin_data/images2500/test_folder/1153/Logo/logo.jpg",
                OpeningTime = DateTime.ParseExact("10:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("18:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+359 74 780 568",
            };

            BookStore6 = new BookStore()
            {
                Id = 6,
                Name = "Хермес",
                Location = "Ларго, ул. „Тодор Александров“ 2, 2700 Благоевград",
                ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipPzW0X4Y2MxHq2gWA7Db5RAe4FgFzdhySCLPc-6=s1360-w1360-h1020-rw",
                OpeningTime = DateTime.ParseExact("09:30", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("19:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+359 89 699 7710",
            };

            BookStore7 = new BookStore()
            {
                Id = 7,
                Name = "Bookpoint - Варна",
                Location = "Варна Център Одесос, ул. „Цар Симеон I“ 1, 9000 Варна",
                ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipOoQHzIG3B8LxmxLjyoCSlDD93L6ftaFLVYFWzX=s680-w680-h510-rw",
                OpeningTime = DateTime.ParseExact("10:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("19:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+359 87 922 8009",
            };

            BookStore8 = new BookStore()
            {
                Id = 8,
                Name = "Waterstones - Piccadilly",
                Location = "203-206 Piccadilly, London W1J 9HD, UK",
                ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipO70gybohOeMNg3RDqh-tICLGqJIkeRoDEEBfOS=s1360-w1360-h1020",
                OpeningTime = DateTime.ParseExact("09:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("21:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+44 20 7851 2400",
            };

            BookStore9 = new BookStore()
            {
                Id = 9,
                Name = "Livraria da Vila",
                Location = "Rua dos Três Irmãos, 11, Vila Progredior, São Paulo - SP, Brazil",
                ImageUrl = "https://images.adsttc.com/media/images/55f6/eac2/adbc/0118/6200/02bf/newsletter/room-surrounded-with-bookshelfs-on-the-ground-floor-and-undergro.jpg?1442245289",
                OpeningTime = DateTime.ParseExact("09:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("22:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+55 11 3813-2731",
            };

            BookStore10 = new BookStore()
            {
                Id = 10,
                Name = "El Ateneo Grand Splendid",
                Location = "Av. Santa Fe 1860, C1425BTH, Buenos Aires, Argentina",
                ImageUrl = "https://indiehoy.com/wp-content/uploads/2019/01/ateneo-640x426.jpg",
                OpeningTime = DateTime.ParseExact("09:30", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("22:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+54 11 4813-6052",
            };

            BookStore11 = new BookStore()
            {
                Id = 11,
                Name = "City Lights Booksellers",
                Location = "261 Columbus Ave, San Francisco, CA 94133, USA",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/fb/City_Lights_Booksellers.jpg",
                OpeningTime = DateTime.ParseExact("10:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("22:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+1 415-362-8193",
            };

            BookStore12 = new BookStore()
            {
                Id = 12,
                Name = "Dymocks - Sydney",
                Location = "424 George St, Sydney NSW 2000, Australia",
                ImageUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/1a/c7/bd/a4/street-level-showing.jpg?w=1200&h=-1&s=1",
                OpeningTime = DateTime.ParseExact("09:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("18:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+61 2 9264 6654",
            };

            BookStore13 = new BookStore()
            {
                Id = 13,
                Name = "Foyles - Charing Cross",
                Location = "107 Charing Cross Rd, London WC2H 0DT, UK",
                ImageUrl = "https://cdn.foyles.co.uk/uat/images/00243704-1200x925.png",
                OpeningTime = DateTime.ParseExact("09:30", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("20:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+44 20 7437 5660",
            };

            BookStore14 = new BookStore()
            {
                Id = 14,
                Name = "Livraria Lello",
                Location = "Rua das Carmelitas 144, 4050-161 Porto, Portugal",
                ImageUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/1b/fa/10/7d/20200910-113406-largejpg.jpg?w=1200&h=-1&s=1",
                OpeningTime = DateTime.ParseExact("10:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("19:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+351 22 200 2037",
            };

            BookStore15 = new BookStore()
            {
                Id = 15,
                Name = "The Bookworm",
                Location = "4 Sanlitun Nan Lu, Chaoyang, Beijing, China",
                ImageUrl = "https://www.thatsmags.com/image/view/201806/the-bookworm.jpg",
                OpeningTime = DateTime.ParseExact("09:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ClosingTime = DateTime.ParseExact("22:00", DateTimeBookStoreFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Contact = "+86 10 6500 2676",
            };
        }

        private void SeedArticles()
        {
            Article1 = new Article()
            {
                Id = 1,
                Title = "Нова книга на Георги Господинов излиза на български пазар",
                Content = "Световноизвестният български писател Георги Господинов, автор на бестселъра „Физика на тъгата“, представя новия си роман, озаглавен „Мечтателите“. Книгата, която беше публикувана първоначално в чужбина, вече е достъпна и за българските читатели. Тя разглежда теми за човешката съдба, изборите и парадоксите на съвременното общество. В този нов роман Господинов не само разглежда социалните проблеми, но и вдъхновява читателите да преосмислят възможностите за промяна в личния и обществения живот. Книгата излиза със специална обложка и предговор от самия автор. Тя е в изданието на издателство „Жанет 45“ и струва 22 лева. Някои от най-забележителните творби на Господинов са преведени на повече от 20 езика, а новото му произведение обещава да се нареди сред най-добрите му успехи.",
                ImageUrl = "/assets/img/coming-soon.jpg",
                DatePublished = DateTime.ParseExact("27/12/2024 12:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            Article2 = new Article()
            {
                Id = 2,
                Title = "Издават новата книга на Владимир Николов - Високо ",
                Content = "Владимир Николов, волейболен шампион на България, Италия и Франция, златен медалист от Шампионската лига (2005 г.), носител на бронзови медали от Световното (2006 г.) и от Европейското (2009 г.) първенство, диагонал №1 в света (2010 г.), дългогодишен капитан на националния отбор, а сега и президент на ВК „Левски“. Владимир Николов – спортист, съпруг, баща, лидер. Това е неговата откровена до болка история, неговият личен поглед към близкото минало и неговият вдъхновяващ завет как бъдещето да бъде по-добро.",
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/v/i/visoko_cover.jpg",
                DatePublished = DateTime.ParseExact("10/12/2024 14:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            Article3 = new Article()
            {
                Id = 3,
                Title = "Дебютната книга на авторка Лиза Джуъл -  И нея вече я нямаше",
                Content = "Ще бъде на пазара на цена от 20,70 лв. Ели Мак беше перфектната дъщеря. На петнайсет години, най-малката от три деца, обичана от родителите си, от приятели, от учители. Златно дете. На Ели й оставаха само дни до изпитите и до едно идилично лято с гаджето ѝ. Целият ѝ живот беше пред нея.\r\n\r\nИ след това, изведнъж, нея вече я нямаше.",
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/i/-/i-neia-veche-ia-niamashe-front.jpg",
                DatePublished = DateTime.ParseExact("05/01/2025 18:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            Article4 = new Article()
            {
                Id = 4,
                Title = "Джон Гришам се завръща с нов трилър – „Престъплението на века“",
                Content = "Джон Гришам, майсторът на юридическите трилъри, издаде своя нов роман, озаглавен „Престъплението на века“. В този новоизлязъл роман Гришам разказва историята на адвокат, който попада в една от най-сложните правни битки на живота си, докато разкрива корупция в най-високите етажи на властта. Книгата обещава да бъде наравно с най-добрите му произведения като „Време за убийство“ и „Клетниците“. Изданието е на издателство „Бард“ и вече е в книжарниците.",
                ImageUrl = "/assets/img/coming-soon.jpg",
                DatePublished = DateTime.ParseExact("12/01/2025 13:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            Article5 = new Article()
            {
                Id = 5,
                Title = "Нова поредица от Джордж Р. Р. Мартин – „Записки за Железния трон“",
                Content = "Феновете на Джордж Р. Р. Мартин ще се радват да разберат, че писателят подготвя нова фентъзи поредица – „Записки за Железния трон“. В първата книга от новата серия, Мартин изследва тъмните тайни на Вестерос и съдбата на онези, които преследват Железния трон, без да се страхуват от последствията. Със сложни герои и непредсказуеми обрати, романът ще задоволи както старите почитатели на автора, така и новите читатели, които търсят нови фентъзи изживявания.",
                ImageUrl = "/assets/img/coming-soon.jpg",
                DatePublished = DateTime.ParseExact("16/12/2024 10:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            Article6 = new Article()
            {
                Id = 6,
                Title = "Предстои - The Strawberry Patch Pancake House",
                Content = "Корицата предстои да бъде заменена с български вариант.",
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/t/h/the_strawberry_patch_pancake_house.jpg",
                DatePublished = DateTime.ParseExact("13/01/2025 15:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            Article7 = new Article()
            {
                Id = 7,
                Title = "Предстои НОВО - Моите приятели",
                Content = "Автор: Фредрик Бакман.",
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/m/o/moite_priyateli.jpg",
                DatePublished = DateTime.ParseExact("17/12/2025 11:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            Article8 = new Article()
            {
                Id = 8,
                Title = "Петър Кьосев представя новия си исторически роман „Времето на звяра“",
                Content = "Петър Кьосев, български писател и историк, представя новия си роман „Времето на звяра“. Книгата е вдъхновена от българската история и разглежда живота през Средновековието, като съчетава факти и художествено въображение. Романът разказва за битките, честта и личните трагедии на героите, които са определяли съдбата на страната. Премиерата на книгата ще бъде на 25 ноември 2024 г. в столичния „Национален дворец на културата“. Изданието е на издателство „Словото“. ",
                ImageUrl = "/assets/img/coming-soon.jpg",
                DatePublished = DateTime.ParseExact("23/11/2024 13:30", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            Article9 = new Article()
            {
                Id = 9,
                Title = "НОВО издание на авторът Coco Mellors - Blue Sisters ",
                Content = "Очаквайте неочакваното.",
                ImageUrl = "https://www.ciela.com/media/catalog/product/cache/9a7ceae8a5abbd0253425b80f9ef99a5/b/l/blue_sisters_-_coco_mellors.jpg",
                DatePublished = DateTime.ParseExact("29/12/2024 09:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };

            Article10 = new Article()
            {
                Id = 10,
                Title = "Елиза Филипова представя дебютния си роман „Тъмнината на душата“",
                Content = "Елиза Филипова, ново име в българската литература, представя дебютния си роман „Тъмнината на душата“. Това е психологически трилър, който потапя читателя в лабиринта на човешките емоции и тайни. Романът разглежда как човешката психика може да бъде засегната от събития извън контрола на индивида. Книгата ще бъде представена на 22 ноември 2024 г. в София, в книжарница „Хеликон“.",
                ImageUrl = "/assets/img/coming-soon.jpg",
                DatePublished = DateTime.ParseExact("19/11/2024 16:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };
        }

        private void SeedArticleComments()
        {
            Comment1 = new ArticleComment()
            {
                Id = 1,
                Title = "Невероятен Гришам!",
                Description = "Джон Гришам е любимият ми автор, няма търпение да се потопя в новия му трилър.",
                ArticleId = 4,
                UserId = "7c8eb412-65a9-4050-8c67-62278f3af93c"
            };

            Comment2 = new ArticleComment()
            {
                Id = 2,
                Title = "Време беше!",
                Description = "Отдавна чакам Мартин да пусне нещо ново. Надявам се да е толкова завладяващо, колкото „Игра на тронове“.",
                ArticleId = 5,
                UserId = "c4fbe2f71-126f-46c3-af99-8dc035eac772"
            };

            Comment3 = new ArticleComment()
            {
                Id = 3,
                Title = "Не е моето",
                Description = "Юридическите драми не са за мен, но уважавам Гришам за таланта му.",
                ArticleId = 4,
                UserId = "9abf1366-cadf-4837-bc30-1b77599ff9cb"
            };

            Comment4 = new ArticleComment()
            {
                Id = 4,
                Title = "Хмм, нещо различно!",
                Description = "Очаквам да видя какво ли ще бъде!.",
                ArticleId = 6,
                UserId = "b4a1311e-dff4-4c3a-9cf7-b794557bdf80"
            };

            Comment5 = new ArticleComment()
            {
                Id = 5,
                Title = "Нека първо завърши старото",
                Description = "Джордж Р. Р. Мартин започва нова поредица, а още не е завършил 'Песен за огън и лед'... малко разочароващо.",
                ArticleId = 5,
                UserId = "9abf1366-cadf-4837-bc30-1b77599ff9cb"
            };

            Comment6 = new ArticleComment()
            {
                Id = 6,
                Title = "Няма никакво описание!",
                Description = "Какво трябва да очакваме?",
                ArticleId = 6,
                UserId = "c4fbe2f71-126f-46c3-af99-8dc035eac772"
            };

            Comment7 = new ArticleComment()
            {
                Id = 7,
                Title = "Звучи заинтригуващо",
                Description = "„Моите приятели“ звучи като че ли са ни останали някакви приятели в днешно време? Ще я прочета веднага щом се появи на пазара!",
                ArticleId = 7,
                UserId = "7c8eb412-65a9-4050-8c67-62278f3af93c"
            };

            Comment8 = new ArticleComment()
            {
                Id = 8,
                Title = "Охо, това ми хареса!",
                Description = "Според мен ще бъде бест селър.",
                ArticleId = 7,
                UserId = "c4fbe2f71-126f-46c3-af99-8dc035eac772"
            };

            Comment9 = new ArticleComment()
            {
                Id = 9,
                Title = "Българската история в литературата",
                Description = "„Времето на звяра“ изглежда като книга, която ще вдъхне живот на забравени исторически епохи. Страхотно, че има такива проекти!",
                ArticleId = 8,
                UserId = "9abf1366-cadf-4837-bc30-1b77599ff9cb"
            };

            Comment10 = new ArticleComment()
            {
                Id = 10,
                Title = "Най-после нещо ново! :)",
                Description = "Очаквам с фолямо вълнение този роман. Звучи чълнуващо и истински докосващо!",
                ArticleId = 10,
                UserId = "c4fbe2f71-126f-46c3-af99-8dc035eac772"
            };
        }

        private void SeedEvents()
        {
            EventOne = new Event()
            {
                Id = 1,
                Topic = "Ден на книгите за Хари Потър",
                Description = "На 17 октомври (четвъртък) 2024 г., от 13:30 ч. ще се проведе събитите: Цял месец, посветен на Хари Потър не ни е достатъчен, затова имаме изненада за вас! За поредна година ще отбележим Деня на книгите за Хари Потър.",
                Location = "Столична библиотека, София",
                StartDate = DateTime.ParseExact("17/10/2024 13:30", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("17/10/2024 16:30", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.libsofia.bg/public//storage/uploads/event/NyEfL4aR00tRO530JbTSI7tbIRhrioTFLnOhXTCV.png",
                Seats = 90,
                TicketPrice = 10
            };

            EventTwo = new Event()
            {
                Id = 2,
                Topic = "Представяне на книгата на д - р Пенчо Кунчев, Анимационният типаж: 1906 - 2012",
                Description = "Анимационният типаж е най-важният компонент в анимационния разказ. Това е всъщност главният герой на рисувания филм, плод на творческите търсения на неговите „родители“ – режисьора и художника. Настоящото изследване проследява появата и развитието му от зората на анимационното кино до наши дни. Книгата съдържа повече от 1000 илюстрации и представлява интерес както за студенти и професионалисти в областта на анимацията, така и за всички любители на изкуството.",
                Location = "НБУ В ЦЕНТЪРа, ул. „Георги С. Раковски“ 191 Б, София",
                StartDate = DateTime.ParseExact("20/11/2024 18:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("20/11/2024 19:30", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://azcheta.com/azcheta-content/uploads/2024/11/73-NBU-v-tsentara-Animatsionniyat-tipazh-20.11.jpg",
                Seats = 80,
                TicketPrice = 15
            };

            EventThree = new Event()
            {
                Id = 3,
                Topic = "Паметна вечер по случай 110 години от рождението на Павел Вежинов",
                Description = "Столична библиотека организира в Американския център паметна вечер по случай 110 години от рождението на големия български писател и кинодраматург Павел Вежинов. В програмата са включени премиери на 9-ото издание на „Нощем с белите коне“, на неиздаваните от повече от 80 години два дебютни сборника с разкази на Павел Вежинов в авторска редакция „Улица без паваж. Дни и вечери“ и най-новото издание на Столична библиотека „Павел Вежинов – биобиблиография“. Ще бъде представена фотодокументалната изложба на Библиотеката, представяща сложния житейски и творчески път на писателя. В паметната вечер с водещ Юрий Дачев ще участват съвременници на Павел Вежинов – известни литератори и филмови творци, издателите Игор Шемтов от „Фама 1“ и Савина Николова от „Orange books“, изследователи на творчеството му. Вечерта ще завърши с прожекция на един от най-интересните документални филми за Павел Вежинов „Сини залези и бели коне“ на БНТ.",
                Location = "Американски център на Столична библиотека, пл. Славейков №4, София",
                StartDate = DateTime.ParseExact("20/11/2024 18:30", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("20/11/2024 20:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://azcheta.com/azcheta-content/uploads/2024/11/Vezhinov.jpg",
                Seats = 200,
                TicketPrice = 20
            };

            EventFour = new Event()
            {
                Id = 4,
                Topic = "Премиера | „Одисея на момичетата от Източна Европа“ на Елица Георгиева",
                Description = "Като кадри от филм се редуват сцени от живота на две българки във Франция в началото на новия век. Въоръжена с „Големия енциклопедичен речник Ларус“ и „Малкия Ларус на добрите обноски“, студентката по кино в Лион открива „страната на свободата, на сирената и на говорещите трамваи“, бори се с тънкостите на френския език, сблъсква се и с едно особено отношение към „момичетата от Изтока“. Разказани увлекателно, с хумор и самоирония, перипетиите ѝ са контрапункт на съдбата на втората героиня. Дора, самотна майка на две момчета, преминала през възродителния процес и безчет житейски несгоди в България, попаднала в мрежа на трафиканти, е принудена да проституира. Борбената Дора, в чийто живот светъл лъч внася само „вълшебната лампа“ на баба ѝ Арифе, също се вписва в разпространеното клише „момиче от Изтока“. Един ден пътищата на двете героини неочаквано се пресичат…",
                Location = "Зала „Славейков“ на Френския институт",
                StartDate = DateTime.ParseExact("21/11/2024 18:30", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("21/11/2024 20:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.colibri.bg/uploads/2024/11/egeorgieva_event.jpg",
                Seats = 30,
                TicketPrice = 50
            };

            EventFive = new Event()
            {
                Id = 5,
                Topic = "ПРЕМИЕРА | МОИТЕ ИСТОРИИ от Георги Борисов",
                Description = "В този внушителен по обем и времеви обхват литературен труд, който авторът е нарекъл „Моите истории“, а някои биха го определили като своеобразен „дневник на писателя“, Георги Борисов представя непубликувани свои стихотворения, мисли и наблюдения, философски есета и мемоарна проза, литературни портрети и свидетелства, сценки и житейски истории, белязали неговия път в продължение на половин век. Сред най-любопитните от разделите в настоящия том е първият – и като форма, и като тематика, – който препраща към Далчевите „Фрагменти“ и представлява особен принос с „опитите“ на поета да разгадае същността на поезията и творческия процес, многоликите маски на битието и холограмите на словото, безкрайните възможности и измамната нищета на българската рима.",
                Location = "Софийска градска художествена галерия",
                StartDate = DateTime.ParseExact("21/11/2024 18:30", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("21/11/2024 20:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.colibri.bg/uploads/2024/11/borisov_event.jpg",
                Seats = 150,
                TicketPrice = 30
            };

            EventSix = new Event()
            {
                Id = 6,
                Topic = "Анархия на сърцето: Премиера на дългоочакваната втора поетична книга на Александър Иванов",
                Description = "„Анархия на сърцето“ е царицата на меланхолиите и обречената любов, но и оголен до рана нерв, който води до удобно премълчаваните въпроси за социалното неравенство и липсата на човешкото в социума, за вируса на страха и самотата, за забравата на миналото и отричането на бъдещето, за ужаса на войната, за самотната вечеря на Бога, за разрухата на сърцето... Тази книга е юмрук право в кривите зъби на мълчанието ни, опит за редакция на света, но и любов към ближния, към поезията и към свободата да обичаш до смърт.",
                Location = "Gramophone Live&Event Club, ул.Будапеща 6 - София",
                StartDate = DateTime.ParseExact("07/11/2024 19:30", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("07/11/2024 21:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://kulturni-novini.info/news/images/40166_1.jpg",
                Seats = 70,
                TicketPrice = 25
            };

            EventSeven = new Event()
            {
                Id = 7,
                Topic = "Премиера на книгата „НаПРАВО в живота” на Румяна Минчева",
                Description = "На 6 ноември (сряда) от 17.30 часа, в залата на Регионална библиотека „Стилиян Чилингиров” – Шумен  ще се състои премиера на книгата „НаПРАВО в живота” на Румяна Мичева. Книгата ще представи проф. Теменуга Тенева, откъси от творбата ще прочете Ирина Николова.",
                Location = "Регионална библиотека Стилиян Чилингиров - Шумен",
                StartDate = DateTime.ParseExact("06/11/2024 17:30", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("06/11/2024 18:30", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://kulturni-novini.info/news/images/40141_1.jpg",
                Seats = 60,
                TicketPrice = 10
            };

            EventEight = new Event()
            {
                Id = 8,
                Topic = "Премиера на Ръцете, с които оцеляваме - новата стихосбирка на Боряна Богданова",
                Description = "Заповядайте на официалната премиера на Ръцете, с които оцеляваме - втората стихосбирка на талантливата Боряна Богданова.",
                Location = "Rоckbar158 - София",
                StartDate = DateTime.ParseExact("05/11/2024 19:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("05/11/2024 22:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://kulturni-novini.info/news/images/40135_1.jpg",
                Seats = 80,
                TicketPrice = 23
            };

            EventNine = new Event()
            {
                Id = 9,
                Topic = "Лексикон представя дебютния сборник с разкази - Нишки от Калина Серкеджиева",
                Description = "Любен Дилов ще представи дебютната книга на Калина Серкеждиева Нишки. Няколко думи ще кажат: Стойко Стоянов, Мира Радева, Азиз Таш. Откъси от книгата ще прочете актрисата Петя Бончева. \r\n\r\nЗа доброто ни настроение ще се погрижат: Two cities one world, Александър Иванов (пиано и вокал). Вокал: Анна Янова. Фотограф: Тихомира Методиева-Тихич. Камера: Димитър Григоров. Водещ: Алина Караханова. Заповядайте на чаша вино и топли приказки!",
                Location = "гр. София, ул. Ангел Кънчев 31, редакцията на списание L'Europeo",
                StartDate = DateTime.ParseExact("29/10/2024 19:30", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("29/10/2024 22:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://kulturni-novini.info/news/images/40081_1.jpg",
                Seats = 130,
                TicketPrice = 50
            };

            EventTen = new Event()
            {
                Id = 10,
                Topic = "Нещо за подарък. Премиера на дебютния сборник с разкази на София Стойнева",
                Description = "Заповядайте на официалната премиера на дебютния сборник с разкази на София Стойнева в уютното пространство на конферентната зала на хотел \"Елит\".\r\n ",
                Location = "Конферентна зала на хотел Елит, гр. Перник",
                StartDate = DateTime.ParseExact("10/10/2024 18:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("10/10/2024 20:00", DateTimeEventFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "/assets/img/coming-soon.jpg",
                Seats = 100,
                TicketPrice = 12
            };
        } 
    }
}

