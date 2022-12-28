using eCommerceApp.Data.Static;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder aplicationBuilder)
        {
            using (var serviceScope = aplicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                //verificam daca bd este creata si exista
                context.Database.EnsureCreated();

                //Cinema
                if(!context.Cinematografe.Any()) //daca nu sunt cinema in bd
                {
                    context.Cinematografe.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Nume = "Cinema City",
                            Logo = "https://logovtor.com/wp-content/uploads/2020/05/cinema-city-romania-logo-vector.png",
                            Descriere = "Cinema City reprezinta cel mai important lant de cinematografe din Romania si din intreaga lume si nu este de mirare ca cinematografele Cinema City din orasele din Romania sunt cele mai populare. Intrand pe teritoriul Cinema City cinefilii vor simti ca au intrat intr-o lume de poveste"
                        },
                        new Cinema()
                        {
                            Nume = "Hollywood Multiplex",
                            Logo = "https://bucurestimall.ro/wp-content/uploads/2017/12/HM_logo.png",
                            Descriere = "Diversitatea genurilor cinematografice si spatiul forte primitor fac ca salile de cinematograf Hollywood Multiplex sa fie intotdeauna pline. Ofertele sunt ele numeroase si cu adevarat tentante."
                        },
                        new Cinema()
                        {
                            Nume = "Cinematograful Moviplex",
                            Logo = "https://plazaromania.ro/wp-content/uploads/2017/02/logo_movieplex_1024px.jpg",
                            Descriere = "Cinematograful Moviplex este unul dintre cele mai cunoscute icnematografe din Romania. Acesta se afla in Bucuresti, mai precis in Plaza Romania, punand la dispozitia cinefililor peste 2500 de locuri, dintre care aproximativ 50 dintre acestea sunt special create pentru persoanele cu diferite dizabilitati. Movieplex este cunsocut, inainte de toate, pentru comoditatea salilor, dar si pentru calitatea proiectiilor."
                        },
                        new Cinema()
                        {
                            Nume = "Samsung IMAX",
                            Logo = "http://assets.sport.ro/assets/procinema/2011/06/15/image_galleries/15833/top-7-cele-mai-tari-cinematografe-din-bucuresti_2.jpg",
                            Descriere = "Experienta unui film la Samsung IMAX merita acei bani platiti extra (un bilet seara te duce pana la 36 ron). Intrare separata, zona privata de racoritoare si popcorn,  impachetare intr-un aer futurist."
                        },
                        new Cinema()
                        {
                            Nume = "Cineplexx Baneasa",
                            Logo = "https://s3proxygw.cineplexx.at/vapc-ro-pimcore/assets/_default_upload_bucket/89339725_136908084528296_2319869874186223616_n_1.jpg",
                            Descriere = "Cineplexx este unul dintre cei mai importanți operatori de cinema din Europa Centrală și de Est și are o experiență de peste 50 de ani în industrie."
                        },
                    });
                    context.SaveChanges();
                }
                //Actori
                if (!context.Actori.Any())
                {
                    context.Actori.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            NumeIntreg = "Matt LeBlanc",
                            Bio = "Matthew Steven LeBlanc (n. 25 iulie 1967) este un actor american. El a câștigat recunoaștere globală prin portretizarea lui Joey Tribbiani în sitcom-ul NBC Friends și în serialul său spin-off, Joey. Pentru munca sa la Friends, LeBlanc a primit trei nominalizări la Primetime Emmy Awards.",
                            PozaProfilURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            NumeIntreg = "Chris Tucker",
                            Bio = "Chris Tucker este un actor cunoscut pentru munca sa în filme precum House Party 3, vineri, Rush Hour 3. Deține 3 milioane de dolari în valoare netă.",
                            PozaProfilURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            NumeIntreg = "Angelina Jolie",
                            Bio = "Angelina Jolie este o actriță și regizoare de film americană; laureată a unui Premiu Oscar, trei Premii Globul de Aur și două Screen Actors Guild Awards. A fost numită de către Forbes cea mai bine plătită actriță de la Hollywood în 2009, 2011, și 2013.",
                            PozaProfilURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            NumeIntreg = "Jim Carrey",
                            Bio = "James Eugene Carrey (n. 17 ianuarie 1962 , Newmarket, Ontario, Canada) este un comedian și actor de film canadiano-american.",
                            PozaProfilURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            NumeIntreg = "Will Smith",
                            Bio = "Willard Carroll Smith, Jr. (n. 25 septembrie 1968 , Philadelphia, Pennsylvania, SUA) este un actor, producător, rapper și compozitor american.",
                            PozaProfilURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Producatori
                if (!context.Producatori.Any())
                {
                    context.Producatori.AddRange(new List<Producator>()
                    {
                        new Producator()
                        {
                            NumeIntreg = "Frank Marshall",
                            Bio = "Frank Wilton Marshall este un producător și regizor american de film. El colaborează adesea cu soția sa, producătorul de film Kathleen Kennedy. Cu Kennedy și Steven Spielberg, a fost unul dintre fondatorii Amblin Entertainment.",
                            PozaProfilURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producator()
                        {
                            NumeIntreg = "Steven Spielberg",
                            Bio = "Steven Allan Spielberg este un regizor, producător și scenarist american. Spielberg este de trei ori câștigător al premiului Oscar și este producătorul de film cu cel mai bun succes financiar al tuturor timpurilor; filmele sale având încasări de aproape 8 miliarde de dolari la nivel mondial.",
                            PozaProfilURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producator()
                        {
                            NumeIntreg = "Quentin Tarantino",
                            Bio = "Quentin Jerome Tarantino este un regizor de film, scenarist, producător și actor american. Cele mai cunoscute creații ale sale sunt Reservoir Dogs, Pulp Fiction, Jackie Brown, Kill Bill Vol. 1, Kill Bill Vol. 2, Death Proof, Inglourious Basterds.",
                            PozaProfilURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producator()
                        {
                            NumeIntreg = "Spike Lee",
                            Bio = "Shelton Jackson Lee (n. 20 martie 1957) este un actor, scriitor, regizor și producător american. Din 1983 până astăzi, compania sa, 40 Acres and a Mule Filmworks, a realizat peste 35 de filme.",
                            PozaProfilURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producator()
                        {
                            NumeIntreg = "Jerry Bruckheimer",
                            Bio = "Jerome Leon Bruckheimer este un producător american de filme și televiziune, cu origini evreiești germane. Câteva dintre filmele cele mai cunoscute la care a fost producător sunt Top Gun, Băieți răi, Pirații din Caraibe, Fortăreața și Armageddon.",
                            PozaProfilURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Filme
                if (!context.Filme.Any())
                {
                    context.Filme.AddRange(new List<Film>()
                    {
                        new Film()
                        {
                            Nume = "Viață, primele semne",
                            Descriere= "Viață, primele semne (titlu original: Life) este un film american din 2017 regizat de Daniel Espinosa. Scenariul este scris de Rhett Reese și Paul Wernick. Rolurile principale au fost interpretate de actorii Jake Gyllenhaal, Rebecca Ferguson și Ryan Reynolds. ",
                            Pret = 39.50,
                            ImagineURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            DataIncepere = DateTime.Now.AddDays(-10),
                            DataIncheiere = DateTime.Now.AddDays(10),
                            IdCinema = 3,
                            IdProducator = 3,
                            CategorieFilm = CategorieFilm.Documentar
                        },
                        new Film()
                        {
                            Nume = "Închisoarea îngerilor",
                            Descriere = "Închisoarea îngerilor este un film american din anul 1994, scris și regizat de Frank Darabont. Filmul este o ecranizare după nuvela lui Stephen King, Rita Hayworth and Shawshank Redemption, publicată inițial în colecția Anotimpuri diferite din 1982.",
                            Pret = 29.50,
                            ImagineURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            DataIncepere = DateTime.Now,
                            DataIncheiere = DateTime.Now.AddDays(3),
                            IdCinema = 1,
                            IdProducator = 1,
                            CategorieFilm = CategorieFilm.Actiune
                        },
                        new Film()
                        {
                            Nume = "Fantoma mea iubită",
                            Descriere = "Fantoma mea iubită este un film american romantic thriller fantastic din 1990. Este scris de Bruce Joel Rubin și regizat de Jerry Zucker.",
                            Pret = 39.50,
                            ImagineURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            DataIncepere = DateTime.Now,
                            DataIncheiere = DateTime.Now.AddDays(7),
                            IdCinema = 4,
                            IdProducator = 4,
                            CategorieFilm = CategorieFilm.Groaza
                        },
                        new Film()
                        {
                            Nume = "Race",
                            Descriere = "Race este un film de dramă sportivă biografică din 2016 despre sportivul afro-american Jesse Owens, care a câștigat patru medalii de aur la Jocurile Olimpice de la Berlin din 1936.",
                            Pret = 39.50,
                            ImagineURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            DataIncepere = DateTime.Now.AddDays(-10),
                            DataIncheiere = DateTime.Now.AddDays(-5),
                            IdCinema = 1,
                            IdProducator = 2,
                            CategorieFilm = CategorieFilm.Documentar
                        },
                        new Film()
                        {
                            Nume = "Scooby-Doo! Mistere cu cap și coadă",
                            Descriere = "Scooby-Doo! Mistere cu cap și coadă este un film 3D de animație produs de Warner Animation Group și bazat pe personajul creat de Hanna-Barbera Scooby-Doo și franciza cu același nume.",
                            Pret = 39.50,
                            ImagineURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            DataIncepere = DateTime.Now.AddDays(-10),
                            DataIncheiere = DateTime.Now.AddDays(-2),
                            IdCinema = 1,
                            IdProducator = 3,
                            CategorieFilm = CategorieFilm.Desen
                        },
                        new Film()
                        {
                            Nume = "Suflete înghețate",
                            Descriere = "Cold Souls este un film de comedie-dramă din 2009, scris și regizat de Sophie Barthes. Filmul îi prezintă pe Paul Giamatti, Dina Korzun, Emily Watson și David Strathairn.",
                            Pret = 39.50,
                            ImagineURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            DataIncepere = DateTime.Now.AddDays(3),
                            DataIncheiere = DateTime.Now.AddDays(20),
                            IdCinema = 1,
                            IdProducator = 5,
                            CategorieFilm = CategorieFilm.Drama
                        }
                    });
                    context.SaveChanges();
                }
                //Actori_Filme
                if (!context.Actori_Filme.Any())
                {
                    context.Actori_Filme.AddRange(new List<Actor_Film>()
                    {
                        new Actor_Film()
                        {
                            IdActor = 1,
                            IdFilm = 1
                        },
                        new Actor_Film()
                        {
                            IdActor = 3,
                            IdFilm = 1
                        },

                         new Actor_Film()
                        {
                            IdActor = 1,
                            IdFilm = 2
                        },
                         new Actor_Film()
                        {
                            IdActor = 4,
                            IdFilm = 2
                        },

                        new Actor_Film()
                        {
                            IdActor = 1,
                            IdFilm = 3
                        },
                        new Actor_Film()
                        {
                            IdActor = 2,
                            IdFilm = 3
                        },
                        new Actor_Film()
                        {
                            IdActor = 5,
                            IdFilm = 3
                        },


                        new Actor_Film()
                        {
                            IdActor = 2,
                            IdFilm = 4
                        },
                        new Actor_Film()
                        {
                            IdActor = 3,
                            IdFilm = 4
                        },
                        new Actor_Film()
                        {
                            IdActor = 4,
                            IdFilm = 4
                        },


                        new Actor_Film()
                        {
                            IdActor = 2,
                            IdFilm = 5
                        },
                        new Actor_Film()
                        {
                            IdActor = 3,
                            IdFilm = 5
                        },
                        new Actor_Film()
                        {
                            IdActor = 4,
                            IdFilm = 5
                        },
                        new Actor_Film()
                        {
                            IdActor = 5,
                            IdFilm = 5
                        },


                        new Actor_Film()
                        {
                            IdActor = 3,
                            IdFilm = 6
                        },
                        new Actor_Film()
                        {
                            IdActor = 4,
                            IdFilm = 6
                        },
                        new Actor_Film()
                        {
                            IdActor = 5,
                            IdFilm = 6
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@netpeace.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@netpeace.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

