using System;

namespace csharp_webapi.Entities
{
    public class ContactBuilder
    {
        private Contact _contact;

       public ContactBuilder()
        {
            _contact = new Contact();
            _contact.Name = "";
            _contact.Number = "";
            _contact.Pronouns = "";
            _contact.Image = "https://i.pinimg.com/originals/0c/3b/3a/0c3b3adb1a7530892e55ef36d3be6cb8.png";
            _contact.Desc = "";
        }

        public ContactBuilder Name(String name) {
            _contact.Name = name;
            return this;
        }

        public ContactBuilder Number(String number) {
            _contact.Number = number;
            return this;
        }

        public ContactBuilder Pronous(String pronous) {
            _contact.Pronouns = pronous;
            return this;
        }

        public ContactBuilder Image(String image) {
            _contact.Image = image;
            return this;
        }
        
        public ContactBuilder Desc(String desc) {
            _contact.Desc = desc;
            return this;
        }

        public Contact Build() {
            return _contact;
        }
    }
}
