using System.Collections.Generic;
using csharp_webapi.Entities;
using csharp_webapi.Builders;

namespace csharp_webapi.Services
{
    public class ContactService
    {
        private readonly Dictionary<int, Contact> _data;

        public ContactService()
        {
            _data = new Dictionary<int, Contact>();
            PopulateData();
        }

        public IEnumerable<Contact> FindAll() 
        {
            return this._data.Values;
        }

        public Contact? FindById(int id) 
        {
            if (this._data.ContainsKey(id)) {
                return this._data[id];
            }
            return null;
        }

        public void Save(Contact contact) {
            _data.Add(_data.Count, contact);
        }

        private void PopulateData() {
            Save(new ContactBuilder()
            .Name("MayMay").Number("51 3244 2133")
            .Image("https://static.poder360.com.br/2020/04/GATO-CORONAVIRUS.jpg")
            .Desc("The liege").Pronous("They/them").Build());
            Save(new ContactBuilder()
            .Name("Wanda").Number("51 9897 8945")
            .Image("https://upload.wikimedia.org/wikipedia/en/d/d9/Elizabeth_Olsen_as_Wanda_Maximoff.jpg")
            .Desc("Marvel goddess").Pronous("She/her").Build());
            Save(new ContactBuilder()
            .Name("Wanda").Number("51 9897 8945")
            .Image("https://upload.wikimedia.org/wikipedia/en/d/d9/Elizabeth_Olsen_as_Wanda_Maximoff.jpg")
            .Desc("Marvel goddess").Pronous("She/her").Build());
            Save(new ContactBuilder()
            .Name("Vision").Number("51 5489 8945")
            .Image("https://terrigen-cdn-dev.marvel.com/content/prod/1x/vision_1.jpg")
            .Desc("Tin man").Pronous("Undefined").Build());
            Save(new ContactBuilder()
            .Name("Bucky").Number("51 9879 8978")
            .Image("https://rollingstone.uol.com.br/media/_versions/sebastian-stan-como-soldado-invernal-reproducao_widelg.jpg")
            .Desc("Angry friend of Captain America")
            .Pronous("He/his").Build());
            Save(new ContactBuilder()
            .Name("Sam").Number("51 4846 5896")
            .Image("https://www.laughingplace.com/w/wp-content/uploads/2021/04/sam-wilson-is-captain-america-in-this-new-the-falcon-and-the-winter-soldier-poster-shared-by-marvel.png")
            .Desc("Happy friend of Captain America")
            .Pronous("He/his").Build());
            Save(new ContactBuilder()
            .Name("Darcy").Number("51 4878 8948")
            .Image("https://kanto.legiaodosherois.com.br/w760-h398-gnw-cfill-q80/wp-content/uploads/2021/02/legiao_YyN7hf2Jevt0.jpg.jpeg")
            .Desc("Genius")
            .Pronous("She/her").Build());
            Save(new ContactBuilder()
            .Name("Agatha").Number("51 8795 8948")
            .Image("https://pbs.twimg.com/media/EzpNapNUcAE177N.jpg")
            .Desc("The master witch")
            .Pronous("She/her").Build());
        }
    }
}
