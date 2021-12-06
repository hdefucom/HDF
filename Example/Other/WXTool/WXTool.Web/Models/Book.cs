namespace WXTool.Web.Models;

public class Book : BaseEntity
{
    /// <summary>
    /// 文献主键
    /// </summary>
    public int BookId { get; set; }


    public string PMID { get; set; }
    public string DOI { get; set; }

    /// <summary>
    /// 文献名称
    /// </summary>
    public string BookName { get; set; }

    /// <summary>
    /// 作者
    /// </summary>
    public string Author { get; set; }
    /// <summary>
    /// 来源
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// 关联文件长链
    /// </summary>
    public string LongUrl { get; set; }
    public string ShortUrl { get; set; }
    public DateTime? ShortUrlCreateTime { get; set; }


    public string OuterChain1 { get; set; }
    public string OuterChain2 { get; set; }
    public string OuterChain3 { get; set; }



}
