using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Program18
{
    public class AlbumInfo
    {
        public string path = @"C:\Users\1392659\Desktop\photoAl\";
        public int id = 1;
        public int idChange(int id)
        {
            while (File.Exists(this.path + id + ".txt"))
            {
                id++;
            }
            this.id = id;
            return id;
        }
    }
    public class PhotoAlbum : AlbumInfo
    {
        private int numberOfPages = 16;
        public int GetNumberOfPages()
        {
            return this.numberOfPages;
        }
        public PhotoAlbum()
        {
            using (StreamWriter sw = new StreamWriter(this.path + idChange(id) + ".txt"))
            {
                sw.WriteLine("Album pages - " + this.numberOfPages);
                Console.WriteLine("ID of your album is " + id);
            }
        }
        public PhotoAlbum(int n)
        {
            while (true)
            {
                try
                {
                    this.numberOfPages = n;
                }
                catch
                {
                    Console.WriteLine("Error, enter only numbers");
                }
                break;
            }
            using (StreamWriter sw = new StreamWriter(this.path + idChange(id) + ".txt"))
            {
                sw.WriteLine("Album pages - " + this.numberOfPages);
                Console.WriteLine("ID of your album is " + id);
            }
        }
        public PhotoAlbum(string n)
        {

        }
    }
    public class BigPhotoAlbum : AlbumInfo
    {
        public BigPhotoAlbum()
        {
            using (StreamWriter sw = new StreamWriter(this.path + idChange(id) + ".txt"))
            {
                sw.WriteLine("Album pages - " + 64);
                Console.WriteLine("ID of your album is " + id);
            }
        }
    }
    public class AlbumTest : AlbumInfo
    {
        public AlbumTest()
        {
            
            int sum = 0;
            new PhotoAlbum(); 
            new PhotoAlbum(24);
            new BigPhotoAlbum();
            id =  idChange(id) - 3;
            int i;
            while (true)
            {
                try
                {
                    using(StreamReader sr = new StreamReader(path + id + ".txt"))
                    {
                        sum = sum +  Convert.ToInt32(sr.ReadLine().Remove(0, 13));
                        id++;
                    }
                }
                catch
                {
                    break;
                }
            }
            Console.WriteLine("All three albums have "+ sum +" pages");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new AlbumTest();
        }
    }
}
