using System;
namespace Tugas_pbo_3006;

internal class Program
{
static void Main(string[] args)
{
    Perusahaan ptMaju = new Perusahaan();

    Manager manager1 = new Manager("Rex", 12000000, 3500000);
    Staff staff1 = new Staff("Ulfatun", 5500000, 1200000);
    Magang magang1 = new Magang("Rismayo", 2500000, 3);
    Freelancer freelancer1 = new Freelancer("ipit", 7000000, 6);

    ptMaju.TambahKaryawan(manager1);
    ptMaju.TambahKaryawan(staff1);
    ptMaju.TambahKaryawan(magang1);
    ptMaju.TambahKaryawan(freelancer1);

    ptMaju.DaftarKaryawan();

    Console.WriteLine("\n================ DEMONSTRASI POLYMORPHISM ================");
    foreach (Karyawan k in ptMaju.daftarKaryawan)
    {
        k.kerja(); 
    }

    Console.WriteLine("\n================ PEMANGGILAN METHOD KHUSUS ================");
    manager1.Memimpin();
    staff1.KerjakanTugas();
    magang1.Belajar();
    freelancer1.AmbilProyek();

    Console.WriteLine($"Gaji Total Manager: Rp{manager1.HitungGajiTotal():N0}");
    Console.WriteLine($"Gaji Total Magang: Rp{magang1.HitungGajiTotal():N0}");

    Console.WriteLine("\n================ DEMONSTRASI SOAL 5 ================");
    Karyawan karyawanPolimorfis = new Staff("Butem", 6000000, 1000000);
    karyawanPolimorfis.kerja();
}
}