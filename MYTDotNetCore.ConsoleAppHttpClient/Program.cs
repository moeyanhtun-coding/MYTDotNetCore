// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");
string jsonStr = await File.ReadAllTextAsync("PickAPileData.json");
var model = JsonConvert.DeserializeObject<PickAPileData.MainDto>(jsonStr);
Console.WriteLine(jsonStr);
Console.ReadLine();

public class LetHtaukBayDin
{
    public class MainDto
    {
        public Question[] questions { get; set; }
        public Answer[] answers { get; set; }
        public string[] numberList { get; set; }
    }

    public class Question
    {
        public int questionNo { get; set; }
        public string questionName { get; set; }
    }

    public class Answer
    {
        public int questionNo { get; set; }
        public int answerNo { get; set; }
        public string answerResult { get; set; }
    }
}

public class PickAPileData
{
    public class MainDto
    {
        public Question[] Questions { get; set; }
        public Answer[] Answers { get; set; }
    }

    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public string QuestionDesp { get; set; }
    }

    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerImageUrl { get; set; }
        public string AnswerName { get; set; }
        public string AnswerDesp { get; set; }
        public int QuestionId { get; set; }
    }
}

public class Movie
{

    public class Rootobject
    {
        public Tbl_Cinemalist[] Tbl_CinemaList { get; set; }
        public Tbl_Cinemaroom[] Tbl_CinemaRoom { get; set; }
        public Tbl_Movielist[] Tbl_MovieList { get; set; }
        public Tbl_Roomseat[] Tbl_RoomSeat { get; set; }
        public Tbl_Movieshowdate[] Tbl_MovieShowDate { get; set; }
        public Tbl_Movieschedule[] Tbl_MovieSchedule { get; set; }
        public Tbl_Seatprice[] Tbl_SeatPrice { get; set; }
    }

    public class Tbl_Cinemalist
    {
        public int CinemaId { get; set; }
        public string CinemaName { get; set; }
        public string CinemaLocation { get; set; }
    }

    public class Tbl_Cinemaroom
    {
        public int RoomId { get; set; }
        public int CinemaId { get; set; }
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public int SeatingCapacity { get; set; }
    }

    public class Tbl_Movielist
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Duration { get; set; }
        public string MoviePhoto { get; set; }
    }

    public class Tbl_Roomseat
    {
        public int SeatId { get; set; }
        public int RoomId { get; set; }
        public int? SeatNo { get; set; }
        public string RowName { get; set; }
        public string SeatType { get; set; }
    }

    public class Tbl_Movieshowdate
    {
        public int ShowDateId { get; set; }
        public int CinemaId { get; set; }
        public int RoomId { get; set; }
        public int MovieId { get; set; }
    }

    public class Tbl_Movieschedule
    {
        public int ShowId { get; set; }
        public int ShowDateId { get; set; }
        public DateTime ShowDateTime { get; set; }
    }

    public class Tbl_Seatprice
    {
        public int SeatPriceId { get; set; }
        public int RoomId { get; set; }
        public string RowName { get; set; }
        public int SeatPrice { get; set; }
    }

}


