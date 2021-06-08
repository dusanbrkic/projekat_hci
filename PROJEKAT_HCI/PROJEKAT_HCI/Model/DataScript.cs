using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJEKAT_HCI.Database;

namespace PROJEKAT_HCI.Model
{
    public class DataScript
    {
        public void FillInData() {
            using (var db = new ProjectDatabase())
            {
                // remove the data
                //db.Admini.RemoveRange(db.Admini);
                //db.Klijenti.RemoveRange(db.Klijenti);
                //db.Organizatori.RemoveRange(db.Organizatori);
                //db.Saradnici.RemoveRange(db.Saradnici);
                //db.Proslave.RemoveRange(db.Proslave);


                Console.WriteLine(db.kofiguracija.Count());
                if (db.kofiguracija.Count() > 0)
                {
                    return;
                }

                Config cfg = new Config()
                {
                    Id = 1,
                    firstRun = true
                };
                db.kofiguracija.Add(cfg);

                Admin nemanja = new Admin()
                {
                    //Id = db.Admini.Count(),
                    Ime = "Nemanja",
                    Prezime = "Milutinovic",
                    BrojTelefona = "0640023344",
                    Email = "nemanjaRSfighter1389@gmail.com",
                    Username = "nelenzi",
                    Password = "nelenzi"
                };

                Klijent nikola = new Klijent()
                {
                    //Id = db.Klijenti.Count(),
                    Ime = "Nikola",
                    Prezime = "Petrovic",
                    BrojTelefona = "064123344",
                    Email = "nikolapigeonman@gmail.com",
                    Username = "nikola",
                    Password = "nikola",
                    Proslave = new List<Proslava>(),
                    Zahtevi = new List<ZahtevProslave>()
                };

                Klijent dzon = new Klijent()
                {
                    //Id = db.Klijenti.Count(),
                    Ime = "Dzon",
                    Prezime = "Bosnic",
                    BrojTelefona = "064123344",
                    Email = "cvetovimaKonopije@gmail.com",
                    Username = "john",
                    Password = "john",
                    Proslave = new List<Proslava>(),
                    Zahtevi = new List<ZahtevProslave>()

                };

                Organizator brka = new Organizator()
                {
                    //Id = db.Organizatori.Count(),
                    Ime = "Dusan",
                    Prezime = "Brkic",
                    BrojTelefona = "0640023344",
                    Email = "brkabigman@gmail.com",
                    Username = "brka",
                    Password = "brka",
                    Proslave = new List<Proslava>()
                };

                Organizator zivanac = new Organizator()
                {
                    //Id = db.Organizatori.Count(),
                    Ime = "Filip",
                    Prezime = "Zivanac",
                    BrojTelefona = "0640023344",
                    Email = "gospodinZivanac@gmail.com",
                    Username = "filip",
                    Password = "filip",
                    Proslave = new List<Proslava>()
                };

                

                Saradnik pecenjaraKnin = new Saradnik()
                {
                    //Id = db.Saradnici.Count(),
                    Lokacija = "Republike Srpske 3",
                    Opis = "Nema slavlja bez dobrog pecenja",
                    Naziv = "Pecenjara Knin",
                    TipSaradnika = TipSaradnika.RESTORAN,
                    
                };
                List<Ponuda> ponudeKnina = new List<Ponuda>();
                Ponuda jagnjecePecenje = new Ponuda()
                {
                    Cena = 500,
                    Opis = "300g jagnjećeg pečenja po osobi",
                    Saradnik = pecenjaraKnin,
                    Klijent = nikola
                };
                Ponuda jarecePecenje = new Ponuda()
                {
                    Cena = 450,
                    Opis = "300g jarećeg pečenja po osobi",
                    Saradnik = pecenjaraKnin
                };
                ponudeKnina.Add(jagnjecePecenje);
                ponudeKnina.Add(jarecePecenje);

                pecenjaraKnin.Ponude = ponudeKnina;

                Saradnik slatkiDani = new Saradnik()
                {
                    //Id = db.Saradnici.Count(),
                    Lokacija = "Narodnog front 58",
                    Opis = "Kolačići za debele",
                    Naziv = "Slatki Dani",
                    TipSaradnika = TipSaradnika.POSLASTICARNICA
                };

                Saradnik belaLadja = new Saradnik()
                {
                    //Id = db.Saradnici.Count(),
                    Lokacija = "Podunavska 21",
                    Opis = "Beli lukac i ljuta paprika",
                    Naziv = "Bela lađa",
                    TipSaradnika = TipSaradnika.RESTORAN
                };

                Proslava proslava1 = new Proslava()
                {
                    //Id = db.Proslave.Count(),
                    Naziv = "Rodjenje Zivancevog sina malog Zivanca",
                    Opis = "Hteo bih neko skromno slavlje rodjenja mog sina, hocu meze i pecenje.",
                    ZahtevProslave = new ZahtevProslave() { Prihvacena = false },
                    PredlogProslave = new PredlogProslave()
                    {
                        Opis = "Moze sve moze!",
                        Prihvacen = false,
                        Zadaci = new List<Zadatak>(),
                        Obavestenja = new List<Obavestenje>()
                    },
                    StatusProslave = StatusProslave.U_ORGANIZACIJI,
                    Klijent = nikola,
                    Organizator = zivanac,
                    DatumOdrzavanja = DateTime.Now,
                    Budzet = 12000,
                    BrojGostiju = 40
                };

                proslava1.PredlogProslave.Zadaci.Add(new Zadatak()
                {
                    Naziv = "Tepisi",
                    Opis = "Potrebno je obezbediti tepise",
                    Status = Status_Zadatka.U_OBRADI,
                    Ponuda = new Ponuda()
                    {
                        Cena = 14000,
                        Opis = "Mi dajemo tepise.",
                        Saradnik = pecenjaraKnin
                    }
                }); 

                proslava1.PredlogProslave.Obavestenja.Add(new Obavestenje() { 
                    Procitano = false, 
                    Sadrzaj = "Korisnik je odreagovao na ponudu!",
                    TimeStamp = DateTime.Now.AddDays(1)
                });

                proslava1.PredlogProslave.Obavestenja.Add(new Obavestenje()
                {
                    Procitano = false,
                    Sadrzaj = "Korisnik je odreagovao na ponudu!",
                    TimeStamp =  DateTime.Now.AddMonths(1)
                });

                proslava1.PredlogProslave.Obavestenja.Add(new Obavestenje()
                {
                    Procitano = false,
                    Sadrzaj = "Korisnik je odreagovao na ponudu!",
                    TimeStamp =  DateTime.Now
                });

                Proslava proslava2 = new Proslava()
                {
                    //Id = db.Proslave.Count(),
                    Naziv = "Ispracanje Nemanje u vojsku",
                    Opis = "Ispracamo naseg Nemanju u vojsku najjaceg coveka.",
                    ZahtevProslave = new ZahtevProslave() { Prihvacena = false },
                    PredlogProslave = new PredlogProslave()
                    {
                        Opis = "Moze sve moze!",
                        Prihvacen = false,
                        Zadaci = new List<Zadatak>(),
                        Obavestenja = new List<Obavestenje>()
                    },
                    StatusProslave = StatusProslave.U_ORGANIZACIJI,
                    Klijent = nikola,
                    Organizator = zivanac,
                    DatumOdrzavanja = DateTime.Now,
                    Budzet = 360000,
                    BrojGostiju = 120

                };
                //enter data
                db.Admini.Add(nemanja);
                db.Klijenti.Add(nikola);
                db.Klijenti.Add(dzon);
                db.Organizatori.Add(brka);
                db.Organizatori.Add(zivanac);
                db.Saradnici.Add(pecenjaraKnin);
                db.Saradnici.Add(slatkiDani);
                db.Saradnici.Add(belaLadja);
                db.Proslave.Add(proslava1);
                db.Proslave.Add(proslava2);
                db.SaveChanges();
            }
        }
    }
}
