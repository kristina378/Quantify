namespace Quantify.Core.Users;

public class Opinion
{
    public long OpinionId { get; init; }

    public long UserId {get; init;}
    public string? UserOpinion {get; set;}
    public int StarsCount{get; init;} // classical model of 5 star rating scale

    protected Opinion(){}
    public Opinion(long id, int starCount, string? opinion)
    {
        UserId = id;
        UserOpinion = opinion;
        StarsCount = starCount;
    }
}