using System.ComponentModel.DataAnnotations;
namespace BaiThiNVA0025.Models;

public class NVAcau3 {
    [Key]
    public string? MaSinhVien {get ; set;}
    public string? TenSinhVien {get ; set;}
    public string? PhoneSinhVien {get ; set;}



}