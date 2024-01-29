using NddcWebsiteLibrary.Model.Home;

namespace NddcWebsiteLibrary.Data.Home
{
    public interface IHomeData
    {
        List<MyNewsModel> AllNews();
        List<MyVideoModel> DisplayMainVideo();
        List<MyPhotoSpeakModel> DisplayPhotos();
        List<MyNewsModel> DisplaySlides();
        List<MyVideoModel> DisplayVideos();
        MyUpdateModel? GetImageByUpdateCategory(string updateCategory);
        List<MyNewsModel> ListHomePageNews();
        List<MyTenderModel> ViewAllTenders();
        List<MyTenderModel> ViewTenderDetails(int Id);
    }
}