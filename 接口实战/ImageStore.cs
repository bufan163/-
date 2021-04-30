using System;
using System.Collections.Generic;
using System.Text;


namespace 接口实战
{

    public interface ImageStore
    {
        String upload(Image image, String bucketName);
        Image download(String url);
    }

    public class Image
    {
    }

    public class AliyunImageStore : ImageStore
    {
        //...省略属性、构造函数等...

        public String upload(Image image, String bucketName)
        {
            createBucketIfNotExisting(bucketName);
            String accessToken = generateAccessToken();
            //...上传图片到阿里云...
            //...返回图片在阿里云上的地址(url)...
            return "";
        }

        public Image download(String url)
        {
            String accessToken = generateAccessToken();
            //...从阿里云下载图片...
            return new Image();
        }

        private void createBucketIfNotExisting(String bucketName)
        {
            // ...创建bucket...
            // ...失败会抛出异常..
        }

        private String generateAccessToken()
        {
            // ...根据accesskey/secrectkey等生成access token
            return "";
        }
    }

    // 上传下载流程改变：私有云不需要支持access token
    public class PrivateImageStore : ImageStore
    {
        public String upload(Image image, String bucketName)
        {
            createBucketIfNotExisting(bucketName);
            //...上传图片到私有云...
            //...返回图片的url...
            return "";
        }

        public Image download(String url)
        {
            //...从私有云下载图片...
            return new Image();
        }

        private void createBucketIfNotExisting(String bucketName)
        {
            // ...创建bucket...
            // ...失败会抛出异常..
        }
    }

    // ImageStore的使用举例
    public class ImageProcessingJob
    {
        private static String BUCKET_NAME = "ai_images_bucket";//存储名称
        //...省略其他无关代码...

        public void process()
        {
            Image image = new Image();//处理图片，并封装为Image对象
            ImageStore imageStore = new PrivateImageStore();
            imageStore.upload(image, BUCKET_NAME);
        }
    }
}
