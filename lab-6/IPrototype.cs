using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    public interface IPrototype<T>
    {
        T Clone();
    }
    public class Section : IPrototype<Section>
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public Section(string title, string text)
        {
            Title = title;
            Text = text;
        }

        public Section Clone()
        {
            return new Section(Title, Text);
        }

        public override string ToString()
        {
            return $"Раздел: {Title}, Текст: {Text}";
        }
    }
    public class Image : IPrototype<Image>
    {
        public string Url { get; set; }

        public Image(string url)
        {
            Url = url;
        }

        public Image Clone()
        {
            return new Image(Url);
        }

        public override string ToString()
        {
            return $"Изображение: {Url}";
        }
    }
    public class Document : IPrototype<Document>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Section> Sections { get; set; }
        public List<Image> Images { get; set; }
        public Document() { }

        public Document(string title, string content, List<Section> sections, List<Image> images)
        {
            Title = title;
            Content = content;
            Sections = sections;
            Images = images;
        }

        public void AddSection(Section section)
        {
            Sections.Add(section);
        }

        public void AddImage(Image image)
        {
            Images.Add(image);
        }

        public Document Clone()
        {
            return new Document(Title, Content, Sections.Select(Section => Section.Clone()).ToList(), Images.Select(Image => Image.Clone()).ToList());
        }

        public override string ToString()
        {
            string sectionsStr = string.Join("\n", Sections);
            string imagesStr = string.Join("\n", Images);

            return $"Документ: {Title}, Контент: {Content}\nРазделы:\n{sectionsStr}\nИзображения:\n{imagesStr}";
        }
    }
    public class DocumentManager
    {
        public Document CreateDocument(IPrototype<Document> prototype)
        {
            return prototype.Clone();
        }
    }
}
