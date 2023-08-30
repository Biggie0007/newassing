using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Alldata
{
    private static void Main(string[] args)
    {
        var carnamess = from s in Staff.GetAllstafs() //leftjoin
                        join c in Staffcar.GetAllstafscar()
                        on s.Id equals c.Cargrade into groupdata
                        from gc in groupdata.DefaultIfEmpty()
                       select new
                      {
                       StaffName = s.Name,
                       StaffCar = gc == null ? "N/A" : gc.Carname,
                      };
              foreach (var item in carnamess)
        {
            Console.WriteLine("Staff Name:{0}--------Staff car: {1}",item.StaffName,item.StaffCar);
        }
      
          Console.WriteLine("--------------------------------------------------------------------------------------");
        var data = Staff.GetAllstafs() // method syntax for left join
                  .GroupJoin(Staffcar.GetAllstafscar(),
                   b => b.Id,
                  o => o.Cargrade,
                 (bls, ols) => new { bls, ols }).SelectMany
                 (x => x.ols.DefaultIfEmpty(),
                 (bt, ol) => new
                 {
                     StaffName = bt.bls.Name,
                     staffcar = ol == null ? "N/A" : ol.Carname,
                 });
   
         foreach (var Value in data)
        {
            Console.WriteLine("Staff Name:{0}--------Staff car: {1}", Value.StaffName,Value.staffcar);
        }
    
    
    
    }
}





public class Staff
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Company { get; set; }
    public int StaffGrade { get; set; }

    public static List<Staff> GetAllstafs()
    {
        return new List<Staff>()
        {



               new Staff() { Id = 2000, Name = "Isaac", Company = "Dangote", StaffGrade = 1 },
            new Staff() { Id = 2001, Name = "Victor", Company = "Shell", StaffGrade = 2 },
              new Staff() { Id = 2002, Name = "Arike", Company = "Walure capitals", StaffGrade = 3 },
              new Staff() { Id = 2003, Name = "Austin", Company = "Sportybet", StaffGrade = 4 },
               new Staff() { Id = 2004, Name = "Victoria", Company = "Overland", StaffGrade =5 },
               new Staff() {Id = 2005, Name = "Yemi", Company = "FMBN",StaffGrade = 6 },
               new Staff() {Id = 2006, Name = "Samuel",Company= "Policeman",StaffGrade=7 },
        };
        
    }
}
public class Staffcar

    {
    public string? Carname { get; set; }
    public int ID { get; set; }
    public int? Cargrade { get; set; }
    public static List<Staffcar> GetAllstafscar()
    {
        return new List<Staffcar>()
         {
       new Staffcar() { Carname = "lexus",ID = 20, Cargrade=2000 },
       new Staffcar() {  Carname = " BMW",ID = 29,Cargrade = 2001 },
       new Staffcar() {Carname = " Benz G-wagon", ID = 200, Cargrade =2002},
       new Staffcar() { Carname = " camry",ID = 203,  Cargrade = 2004 },
       new Staffcar() {Carname = " porch", ID = 204,Cargrade = 2005},
        };






    }
}


