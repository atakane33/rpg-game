using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Karakter
    {
        public string karakterİsim;

        private int saldırı = 7;

        private int can = 100;

        public int iyileşme;

        public int s_saldırı
        {
            get
            {
                return saldırı;
            }

            set
            {
                saldırı = value;
            }
        }

        public int c_can
        {
            get
            {
                return can;
            }

            set
            {
                can = value;
            }

        }

        public Karakter(string isim, int _saldırı, int _can)
        {

            karakterİsim = isim;

            s_saldırı = _saldırı;

            c_can = _can;
        }

        public void KarakterDeğer()
        {
            Console.Write("\nKarakterin İsmi : {0} ", karakterİsim);

            Console.WriteLine("\n************************");

            Console.Write("\nKarakterin Saldırı Gücü : {0} ", s_saldırı);

            Console.WriteLine("\n************************");

            Console.Write("\nKarakterin Can Değeri : {0} ", c_can);

        }

        public void k_saldırı(Karakter karşı)
        {
            karşı.c_can = karşı.c_can - this.s_saldırı;
        }        
       

    }

    public class Kişi : Karakter
    {
        public Kişi (string isim, int __saldırı, int __can) : base (isim, __saldırı, __can)
        {

        }
        public void Canlandır(Karakter karşı)
        {
            int sınır = 0;

            Random rnd = new Random();

            iyileşme = rnd.Next(0, 20);

            if (karşı.c_can > iyileşme)
            {
                karşı.c_can = karşı.c_can + iyileşme;

                sınır++;

                if (sınır == 3)
                {
                    Console.Write("Canlandırma Hakkınız Kalmadı ! ");
                }
            }

            if (iyileşme > karşı.c_can)
            {
                karşı.c_can = iyileşme;
            }
        }
        public void Adalet(Karakter karşı)
        {
            int sınır = 0;

            if (c_can > 0 && c_can <= 100)
            {
                karşı.c_can = karşı.c_can - (karşı.s_saldırı + 33);

                sınır++;

                if (sınır == 2)
                {
                    Console.Write("Adalet Saldırısı Hakkınız Kalmadı ! ");
                }
            }

        }

        public void KritikSaldırı(Karakter karşı)
        {
            Random rnd = new Random();

            int sınır = 0;

            int rastgele = rnd.Next(0, 100);

            if (rastgele > 0 && rastgele <= 10)
            {
                karşı.c_can = karşı.c_can - (karşı.s_saldırı * 2);

                sınır++;

                if (sınır == 3)
                {
                    Console.Write("Kritik Saldırı Hakkınız Kalmadı ! ");
                }
            }

            else
            {
                karşı.s_saldırı = 0;

                karşı.c_can = karşı.c_can - karşı.s_saldırı;

                sınır++;

                if (sınır == 2)
                {
                    Console.Write("Kritik Saldırı Hakkınız Kalmadı ! ");
                }


            }

        }
        public void CanCalma(Karakter karşı)
        {
            int sınır = 0;

            if (c_can > 0 && c_can <= 100)
            {
                karşı.c_can = karşı.c_can + karşı.s_saldırı;

                sınır++;

                if (sınır == 2)
                {
                    Console.WriteLine("Can Çalma Saldırınız Kalmadı ! ");
                }
            }
        }
        public int Seçim()
        {
            int seçim1 = 0, seçim2;

            while (true)
            {
                Console.WriteLine("Hamleni Seç ! ");

                Console.WriteLine("1) Normal Saldırı ");

                Console.WriteLine("2) Canlandır ");

                Console.WriteLine("3) Özel Saldırı Menüsü ");

                bool test = int.TryParse(Console.ReadLine(), out seçim1);

                if (!test || seçim1 > 3 || seçim1 < 0)
                {
                    Console.WriteLine("Menüde böyle bir seçenek yok ! ");

                    Console.ReadLine();

                    Console.Clear();

                    continue;
                }

                if (seçim1 == 3)
                {
                    Console.WriteLine("Hamleni Seç ! ");

                    Console.WriteLine("1) Adalet ");

                    Console.WriteLine("2) Kritik Saldırı ");

                    Console.WriteLine("3) Can Çalma ");

                    bool test2 = int.TryParse(Console.ReadLine(), out seçim2);

                    if (!test2 || seçim2 > 3 || seçim2 < 0)
                    {
                        Console.WriteLine("Menüde böyle bir seçenek yok ! ");

                        Console.ReadLine();

                        Console.Clear();

                        continue;
                    }

                    if (seçim2 == 1)
                    {
                        seçim1 = 4;
                    }

                    if (seçim2 == 2)
                    {
                        seçim1 = 5;
                    }

                    if (seçim2 == 3)
                    {
                        seçim1 = 6;
                    }
                }

                if (seçim1 == 1 || seçim1 == 2 || seçim1 == 4 || seçim1 == 5 || seçim1 == 6)
                {
                    break;
                }

            }

            return seçim1;
        }
        public void Karar(int karar, Düşman karşı)
        {
            if (karar == 1)
            {
                k_saldırı(karşı);

                Console.WriteLine("Normal Saldırı Kullanıldı ! ");
            }

            if (karar == 2)
            {
                c_can += iyileşme;
                
                Canlandır(karşı);

                Console.WriteLine("Canlandır Hamlesi Kullanıldı ! {0} Kadar Can Değeri Yenilendi ! ", iyileşme);

                Console.WriteLine("Yeni Can Değeri : {0} ", c_can + iyileşme);
            }

            if (karar == 4)
            {
                Adalet(karşı);

                Console.WriteLine("Adalet Saldırısı Kullanıldı !");
            }

            if (karar == 5)
            {
                KritikSaldırı(karşı);

                Console.WriteLine("Kritik Saldırısı Kullanıldı ! ");
            }

            if (karar == 6)
            {
                CanCalma(karşı);

                Console.WriteLine("Can Çalma Saldırısı Kullanıldı ! ");
            }

        }

    }

    public class Düşman : Karakter
    {
        public int saldırıSayısı;

        public Düşman(string isim, int __saldırı, int __can): base (isim, __saldırı, __can)
        {
           
        }

        public int düşmanSeçim()
        {
            int DüşmanSeçim;

            Random rnd = new Random();

            DüşmanSeçim = rnd.Next(1, saldırıSayısı + 1);

            return DüşmanSeçim;
        }

    }

    public class Goblin : Düşman
    {
        public Goblin (string _isim, int __saldırı, int __can): base (_isim,__saldırı, __can)
        {
            saldırıSayısı = 3;
        }
    
        public void Hançer (Karakter karşı)
        {
            karşı.c_can = karşı.c_can - (karşı.s_saldırı + 3);
        }
    
        public void GoblinKritikSaldırı (Karakter karşı)
        {
            karşı.c_can = karşı.c_can - (karşı.s_saldırı * 2);
        }


        public void GoblinSecim(int seçim , Karakter karşı)
        {
            if (seçim == 1)
            {
                k_saldırı(karşı);

                Console.WriteLine("Goblin Sana Vurdu ! ");

            }
        
            if (seçim == 2)
            {
                Hançer(karşı);

                Console.WriteLine("Goblin Hançer Saldırısını Kullandı ! ");
            }
        
            if (seçim == 3)
            {
                GoblinKritikSaldırı(karşı);

                Console.WriteLine("Goblin Kritik Saldırısını Kullandı ! ");
            }

            Console.ReadLine();

            Console.Clear();
        
        
        }

    
    }

    public class AnkaKuşu : Düşman
    {
        public AnkaKuşu(string __isim, int __saldırı, int __can) : base (__isim, __saldırı, __can)
        {
            saldırıSayısı = 4;
        }
    
    
        public void AlevSaldırısı(Karakter karşı)
        {
            karşı.c_can = karşı.c_can - (karşı.s_saldırı + 18);
        }
    
        public void AnkaKritikSaldırı(Karakter karşı)
        {
            karşı.c_can = karşı.c_can - (karşı.s_saldırı * 2);
        }

        public void ZehirSaldırısı(Karakter karşı)
        {
            karşı.c_can = karşı.c_can - (karşı.s_saldırı + 28);
        }

        public void AnkaSecim(int seçim, Karakter karşı)
        {
            if (seçim == 1)
            {
                k_saldırı(karşı);

                Console.WriteLine("Anka Kuşu Sana Vurdu ! ");
            }
        
            if (seçim == 2)
            {
                AlevSaldırısı(karşı);

                Console.WriteLine("Anka Kuşu Alev Saldırısını Kullandı ! ");
            }
        
            if (seçim == 3)
            {
                AnkaKritikSaldırı(karşı);

                Console.WriteLine("Anka Kuşu Kritik Saldırısını Kullandı ! ");
            }

            if (seçim == 4)
            {
                ZehirSaldırısı(karşı);

                Console.WriteLine("Anka Kuşu Zehir Saldırısını Kullandı !");
            }


            Console.ReadLine();

            Console.Clear();   
        
        }


    }

    public class Yeti : Düşman
    {
        public Yeti(string ___isim, int _saldırı, int _can) : base (___isim, _saldırı, _can)
        {
            saldırıSayısı = 5;
        }
    
        public void KartopuSaldırısı(Karakter karşı)
        {
            karşı.c_can = karşı.c_can - (karşı.s_saldırı + 8); 
        }
        
        public void Kükre(Karakter karşı)
        {            
            karşı.s_saldırı = ((karşı.s_saldırı * 15) / 10);

            karşı.c_can = karşı.c_can - karşı.s_saldırı;
        }
    
        public void CanBas(Karakter karşı)
        {
            karşı.c_can += 50;

            karşı.c_can = karşı.c_can - karşı.s_saldırı;

        }

        public void YetiKritik(Karakter karşı)
        {
            karşı.c_can = karşı.c_can - (karşı.s_saldırı * 2);
        }

        public void YetiSeçim(int seçim, Karakter karşı)
        {
            if (seçim == 1)
            {
                k_saldırı(karşı);

                Console.WriteLine("Yeti Sana Vurdu ! ");
            }

            if (seçim == 2)
            {
                KartopuSaldırısı(karşı);

                Console.WriteLine("Yeti Kartopu Saldırısı Kullandı ! ");
            }

            if (seçim == 3)
            {
                Kükre(karşı);

                Console.WriteLine("Yeti Kükredi ! ");
            }

            if (seçim == 4)
            {
                CanBas(karşı);

                Console.WriteLine("Yeti Kendini İyileştirdi ! ");
            }

            if (seçim == 5)
            {
                YetiKritik(karşı);

                Console.WriteLine("Yeti Kritik Saldırısı Kullandı ! ");
            }

            Console.ReadLine();

            Console.Clear();
        
        
        }
    
    }


    public class Savaş
    {

        public static void KarakterÖlme(Karakter karakter)
        {
            if (karakter.c_can <= 0)
            {
                Console.Clear();

                Console.WriteLine("Ah Ah ! Ahhhhhhhh ! ");

                Console.WriteLine("Öldün ! Bir Sonraki Sefere ! ");

                Console.ReadLine();

                Environment.Exit(0);
            }
        }

    
        public static void KarakterDeğerYaz(Karakter karakter1, Karakter karakter2)
        {
            karakter1.KarakterDeğer();

            Console.WriteLine("");

            karakter2.KarakterDeğer();

            Console.WriteLine("");
        }
    
        public static void GoblinSavaş(Kişi karakter, Goblin goblin)
        {
            while (karakter.c_can > 0 && goblin.c_can > 0)
            {
                KarakterDeğerYaz(karakter, goblin);

                karakter.Karar(karakter.Seçim(), goblin);

                if (goblin.c_can > 0)
                {
                    goblin.GoblinSecim(goblin.düşmanSeçim(), karakter);

                    KarakterÖlme(karakter);
                }
            }

            Console.WriteLine("{0} öldü ", goblin.karakterİsim);

            Console.ReadLine();

            Console.Clear();
              
        }

        public static void AnkaSavaş(Kişi karakter, AnkaKuşu anka)
        {
            while (karakter.c_can > 0 && anka.c_can > 0)
            {
                KarakterDeğerYaz(karakter, anka);

                karakter.Karar(karakter.Seçim(), anka);

                if (anka.c_can > 0)
                {
                    anka.AnkaSecim(anka.düşmanSeçim(), karakter);

                    KarakterÖlme(karakter);
                }
            }

            Console.WriteLine("{0} öldü ", anka.karakterİsim);

            Console.ReadLine();

            Console.Clear();

        }

        public static void YetiSavaş(Kişi karakter, Yeti yeti)
        {
            while (karakter.c_can > 0 && yeti.c_can > 0)
            {
                KarakterDeğerYaz(karakter, yeti);

                karakter.Karar(karakter.Seçim(), yeti);

                if (yeti.c_can > 0)
                {
                    yeti.YetiSeçim(yeti.düşmanSeçim(), karakter);

                    KarakterÖlme(karakter);
                }
            }

            Console.WriteLine("{0} öldü ", yeti.karakterİsim);

            Console.ReadLine();

            Console.Clear();

        }

    }

    class Hikaye
    {
        public static void GoblinÖnce()
        {
            Console.WriteLine("Sana Kötü Bakan Goblinlerle Karşılaştın ! ");

            Console.ReadLine();

            Console.Clear();
        }

        public static void AnkaÖnce()
        {
            Console.WriteLine("Goblinleri Geçtin Tebrikler Ama Daha Bitmedi ! ");

            Console.WriteLine("Sırada Anka Kuşu Var ! ");

            Console.ReadLine();

            Console.Clear();
        }

        public static void YetiÖnce()
        {
            Console.WriteLine("Bravo Tebrikler ! ");

            Console.Write("Ve En Sonunda Yetiyle Karşılaştın ! ");

            Console.ReadLine();

            Console.Clear();
        }
        public static void Son()
        {
            Console.WriteLine("Oyunu Bitirdin ! Tebrikler ! ");

            Console.ReadLine();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Karakter İsmi Gir : ");

            string isimgir = Console.ReadLine();

            Kişi isim = new Kişi(isimgir, 7, 100);

            Goblin velvet = new Goblin("Velvet ", 5, 50);

            AnkaKuşu hudson = new AnkaKuşu("Hudson ", 10, 75);

            Yeti hornet = new Yeti("Hornet ", 12, 100);

            Hikaye.GoblinÖnce();

            Savaş.GoblinSavaş(isim, velvet);

            Hikaye.AnkaÖnce();

            Savaş.AnkaSavaş(isim, hudson);

            Hikaye.YetiÖnce();

            Savaş.YetiSavaş(isim, hornet);

            Hikaye.Son();
        }
    }
}
