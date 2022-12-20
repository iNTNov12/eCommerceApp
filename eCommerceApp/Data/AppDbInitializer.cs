using eCommerceApp.Models;
using Microsoft.AspNetCore.Builder;
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

                }
                //Filme
                if (!context.Filme.Any())
                {

                }
                //Actori_Filme
                if (!context.Actori_Filme.Any())
                {

                }
            }
        }
    }
}

