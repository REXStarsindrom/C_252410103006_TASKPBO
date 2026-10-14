using Tugas_pbo_3006;
using System;
using System.Collections.Generic;

namespace Tugas_pbo_3006

{
    public class Karyawan
    {
        public string Nama { get; set; }
        public double Gaji { get; set; }

        public Karyawan(string nama, double gaji)
        {
            Nama = nama;
            Gaji = gaji;
        }
        public virtual void kerja()
        {
            Console.WriteLine($"{Nama}Sedang bekerja");
        }

        public virtual void InfoKaryawan()
        {
            Console.WriteLine($"Nama: {Nama}, Gaji: {Gaji:N0}");
        }


    }
}

public class Tetap : Karyawan
{
    public double Tunjangan { get; set; }
    public Tetap(string nama, double gaji, double tunjangan) : base(nama, gaji)
    {
        Tunjangan = tunjangan;
    }

    public double HitungGajiTotal()
    {
        return Gaji + Tunjangan;
    }

    public override void kerja()
    {
        Console.WriteLine($"{Nama} Sedang bekerja sebagai karyawan tetap");
    }
    public override void InfoKaryawan()
    {
        Console.WriteLine($"Nama: {Nama}, Gaji Pokok: Rp{Gaji:N0}, Tunjangan: Rp{Tunjangan:N0}, Total Gaji: Rp{HitungGajiTotal():N0}");
    }
}



public class Kontrak : Karyawan
{
    public double Tunjangan { get; set; }
    public Kontrak(string nama, double gaji, double tunjangan) : base(nama, gaji)
    {
        Tunjangan = tunjangan;
    }

    public double HitungGajiTotal()
    {
        return Gaji + Tunjangan;
    }

    public override void kerja()
    {
        Console.WriteLine($"{Nama} Sedang bekerja sebagai karyawan kontrak");
    }
    public override void InfoKaryawan()
    {
        Console.WriteLine($"Nama: {Nama}, Gaji Pokok: Rp{Gaji:N0}, Tunjangan: Rp{Tunjangan:N0}, Total Gaji: Rp{HitungGajiTotal():N0}");
    }
}


public class Manager : Tetap
{
    public Manager(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

    public void Memimpin()
    {
        Console.WriteLine($"{Nama} sedang memimpin rapat divisi dan menentukan strategi perusahaan.");
    }

    public override void kerja()
    {
        Console.WriteLine($"{Nama} (Manager) sedang mengawasi jalannya proyek dan kinerja tim.");
    }
}

public class Staff : Tetap
{
    public Staff(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

    public void KerjakanTugas()
    {
        Console.WriteLine($"{Nama} sedang menyelesaikan tugas operasional harian.");
    }

    public override void kerja()
    {
        Console.WriteLine($"{Nama} (Staff) sedang memproses berkas dan tugas administratif.");
    }
}

public class Magang : Kontrak
{
    public Magang(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }

    public void Belajar()
    {
        Console.WriteLine($"{Nama} sedang mengikuti sesi mentoring dan mempelajari alur kerja sistem.");
    }

    public override void kerja()
    {
        Console.WriteLine($"{Nama} (Magang) sedang bekerja sambil belajar menyelesaikan tugas ringan.");
    }
}

public class Freelancer : Kontrak
{
    public Freelancer(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }

    public void AmbilProyek()
    {
        Console.WriteLine($"{Nama} sedang mengambil dan menandatangani kesepakatan proyek baru.");
    }

    public override void kerja()
    {
        Console.WriteLine($"{Nama} (Freelancer) sedang menyelesaikan deliverable proyek sesuai tenggat.");
    }
}

public class Perusahaan
{
    public List<Karyawan> daftarKaryawan { get; set; } = new List<Karyawan>();

    public void TambahKaryawan(Karyawan karyawan)
    {
        daftarKaryawan.Add(karyawan);
        Console.WriteLine($"[Sistem] {karyawan.Nama} berhasil ditambahkan.");
    }

    public void DaftarKaryawan()
    {
        Console.WriteLine("\n================ DAFTAR KARYAWAN ================");
        foreach (var k in daftarKaryawan)
        {
            k.InfoKaryawan();
        }
    }

}


    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Objek Perusahaan
            Perusahaan ptMaju = new Perusahaan();

            // 2. Objek Karyawan
            Manager manager1 = new Manager("Budi Santoso", 12000000, 3500000);
            Staff staff1 = new Staff("Siti Rahma", 5500000, 1200000);
            Magang magang1 = new Magang("Andi Wijaya", 2500000, 3);
            Freelancer freelancer1 = new Freelancer("Bambang Heru", 7000000, 6);

            // 3. Tambahkan ke Perusahaan
            ptMaju.TambahKaryawan(manager1);
            ptMaju.TambahKaryawan(staff1);
            ptMaju.TambahKaryawan(magang1);
            ptMaju.TambahKaryawan(freelancer1);

            // 4. Tampilkan semua data
            ptMaju.DaftarKaryawan();

            // 5. Demonstrasi Polymorphism
            Console.WriteLine("\n================ DEMONSTRASI POLYMORPHISM ================");
            foreach (Karyawan k in ptMaju.daftarKaryawan)
            {
                k.kerja(); // Menggunakan huruf 'k' kecil sesuai definisi di Class Karyawan
            }

            // 6. Pemanggilan Method Khusus
            Console.WriteLine("\n================ PEMANGGILAN METHOD KHUSUS ================");
            manager1.Memimpin();
            staff1.KerjakanTugas();
            magang1.Belajar();
            freelancer1.AmbilProyek();

            // Menampilkan nilai kembalian dari HitungGajiTotal
            Console.WriteLine($"Gaji Total Manager: Rp{manager1.HitungGajiTotal():N0}");
            Console.WriteLine($"Gaji Total Magang: Rp{magang1.HitungGajiTotal():N0}");

            // Demonstrasi Soal 5
            Console.WriteLine("\n================ DEMONSTRASI SOAL 5 ================");
            Karyawan karyawanPolimorfis = new Staff("Eko Prasetyo", 6000000, 1000000);
            karyawanPolimorfis.kerja(); // Menggunakan huruf 'k' kecil
        }
    }
}