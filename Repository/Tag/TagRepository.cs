using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAO;

namespace Repository
{
    public class TagRepository : ITagRepository
    {
        public void DeleteTag(Tag tag) => TagDao.DeleteTag(tag);

        public List<Tag> GetTag() => TagDao.GetTag();

        public Tag GetTagByID(int id)
        {
            Tag tag = new Tag();
            tag = TagDao.GetTag().SingleOrDefault(p => p.TagId == id);
            return tag;
        }

        public void SaveTag(Tag tag) => TagDao.SaveTag(tag);

        public void UpdateTag(Tag tag) => TagDao.UpdateTag(tag);
    }
}
