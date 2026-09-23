#nullable disable
using System;
using System.Text;

namespace PostLogisticsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // =============================================================
            // ЧАСТИНА 1. УЗАГАЛЬНЕНІ МЕТОДИ (ОБРОБКА МАСИВІВ)
            // =============================================================
            Console.WriteLine("============================================================");
            Console.WriteLine("        ЧАСТИНА 1. УЗАГАЛЬНЕНІ МЕТОДИ (ОБРОБКА МАСИВІВ)     ");
            Console.WriteLine("============================================================");

            int[] numbers = { 8, 25, 3, 14, 42, 9 };
            Console.WriteLine("Числовий масив: " + string.Join(", ", numbers));
            Console.WriteLine("Індекс числа 14: " + ArrayUtils.FindIndex(numbers, 14));
            Console.WriteLine("Мінімальне число: " + ArrayUtils.GetMinimum(numbers));
            Console.WriteLine("Максимальне число: " + ArrayUtils.GetMaximum(numbers));
            ArrayUtils.Invert(numbers);
            Console.WriteLine("Реверс масиву: " + string.Join(", ", numbers));

            Console.WriteLine();
            string[] cities = { "Вінниця", "Тернопіль", "Луцьк", "Чернівці" };
            Console.WriteLine("Масив міст: " + string.Join(", ", cities));
            Console.WriteLine("Індекс міста 'Луцьк': " + ArrayUtils.FindIndex(cities, "Луцьк"));
            Console.WriteLine("Мінімальне за алфавітом: " + ArrayUtils.GetMinimum(cities));
            Console.WriteLine("Максимальне за алфавітом: " + ArrayUtils.GetMaximum(cities));
            ArrayUtils.Invert(cities);
            Console.WriteLine("Реверс масиву: " + string.Join(", ", cities));

            // =============================================================
            // ЧАСТИНА 2. УЗАГАЛЬНЕНИЙ РЕПОЗИТОРІЙ СУТНОСТЕЙ
            // =============================================================
            Console.WriteLine("\n============================================================");
            Console.WriteLine("    ЧАСТИНА 2. УЗАГАЛЬНЕНИЙ РЕПОЗИТОРІЙ (POSTING ТА CONTACT) ");
            Console.WriteLine("============================================================");

            // 1. Тестування відправлень
            Console.WriteLine("\n--- 1. Репозиторій відправлень (Posting) ---");
            IRepository<Posting> postRepo = new GenericRepository<Posting>();

            postRepo.Add(new Posting
            {
                Id = 101,
                TrackCode = "EXP-88910",
                ParcelWeight = 3.4,
                DepartureAddress = "м. Вінниця, вул. Соборна, 45",
                DestinationAddress = "м. Тернопіль, вул. Руська, 10",
                DeliveryStatus = "Сформовано"
            });

            postRepo.Add(new Posting
            {
                Id = 102,
                TrackCode = "NP-77215",
                ParcelWeight = 12.8,
                DepartureAddress = "м. Ужгород, пл. Театральна, 3",
                DestinationAddress = "м. Луцьк, пр. Волі, 14",
                DeliveryStatus = "Транспортування"
            });

            postRepo.Add(new Posting
            {
                Id = 103,
                TrackCode = "DHL-3004",
                ParcelWeight = 0.75,
                DepartureAddress = "м. Чернівці, вул. Головна, 22",
                DestinationAddress = "м. Рівне, вул. Соборна, 5",
                DeliveryStatus = "Очікує видачі"
            });

            Console.WriteLine("\n[Пошук ID = 102]: " + postRepo.GetById(102));

            Console.WriteLine("\n[Оновлення ID = 101]:");
            postRepo.Update(new Posting
            {
                Id = 101,
                TrackCode = "EXP-88910",
                ParcelWeight = 3.4,
                DepartureAddress = "м. Вінниця, вул. Соборна, 45",
                DestinationAddress = "м. Тернопіль, вул. Руська, 10",
                DeliveryStatus = "Доставлено адресату"
            });

            Console.WriteLine("\n[Видалення ID = 103]:");
            postRepo.Delete(103);

            Console.WriteLine("\n[Залишок відправлень у сховищі]:");
            foreach (var post in postRepo.GetAll())
            {
                Console.WriteLine(" - " + post);
            }

            // 2. Тестування контактних осіб
            Console.WriteLine("\n--- 2. Репозиторій контактних осіб (ContactPerson) ---");
            IRepository<ContactPerson> clientRepo = new GenericRepository<ContactPerson>();

            clientRepo.Add(new ContactPerson
            {
                Id = 501,
                FullName = "Дмитро Мельник",
                PhoneNumber = "+380671112233",
                EmailAddress = "d.melnyk@gmail.com"
            });

            clientRepo.Add(new ContactPerson
            {
                Id = 502,
                FullName = "Андрій Кравчук",
                PhoneNumber = "+380502223344",
                EmailAddress = "a_kravchuk@ukr.net"
            });

            clientRepo.Add(new ContactPerson
            {
                Id = 503,
                FullName = "Богдан Савченко",
                PhoneNumber = "+380933334455",
                EmailAddress = "b_savchenko@outlook.com"
            });

            Console.WriteLine("\n[Пошук ID = 501]: " + clientRepo.GetById(501));

            Console.WriteLine("\n[Оновлення ID = 502]:");
            clientRepo.Update(new ContactPerson
            {
                Id = 502,
                FullName = "Андрій Кравчук-Мороз",
                PhoneNumber = "+380509998877",
                EmailAddress = "kravchuk_new@ukr.net"
            });

            Console.WriteLine("\n[Видалення ID = 503]:");
            clientRepo.Delete(503);

            Console.WriteLine("\n[Залишок клієнтів у сховищі]:");
            foreach (var client in clientRepo.GetAll())
            {
                Console.WriteLine(" - " + client);
            }

            // 3. Перевірка роздільності
            Console.WriteLine("\n--- 3. Перевірка незалежності пам'яті ---");
            Console.WriteLine($"Кількість відправлень: {postRepo.GetAll().Count}");
            Console.WriteLine($"Кількість клієнтів: {clientRepo.GetAll().Count}");
            Console.WriteLine("Дані репозиторіїв ізольовані та не змішуються.");

            Console.WriteLine("\nНатисніть Enter для завершення...");
            Console.ReadLine();
        }
    }
}
