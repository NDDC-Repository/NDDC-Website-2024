using NddcWebsiteLibrary.Model.Home;

namespace NddcWebsiteLibrary.Data.Home
{
    public interface IHomeData
    {
        List<MyNewsModel> AllNews();
        List<MyPhotoSpeakModel> DisplayPhotos();
        List<MyNewsModel> DisplaySlides();
        MyUpdateModel? GetImageByUpdateCategory(string updateCategory);
        List<MyNewsModel> ListHomePageNews();
    }
}