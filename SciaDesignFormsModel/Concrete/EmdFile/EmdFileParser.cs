using System;
using System.IO.Compression;
using System.Linq;
using Ioc_Help.Abstract;
using SciaDesignFormsModel.Abstract.EmdFile;
using System.IO;

namespace SciaDesignFormsModel.Concrete.EmdFile
{
    public class EmdFileParser : IEmdFileParser
    {
        public EmdFileParser(
            IResolver<IEmdFileStrcture> resEmdFileStrcture,
            IResolver<IEmdFileMember> resEmdFileMember,
            IResolver<IEmdFileSection> resEmdFileSection)
        {
            m_resEmdFileStrcture = resEmdFileStrcture;
            m_resEmdFileMember = resEmdFileMember;
            m_resEmdFileSection = resEmdFileSection;
        }

        #region MEMBERS;
        readonly IResolver<IEmdFileStrcture> m_resEmdFileStrcture;
        readonly IResolver<IEmdFileMember> m_resEmdFileMember;
        readonly IResolver<IEmdFileSection> m_resEmdFileSection;
        #endregion

        public IEmdFileStrcture Parse(IEmdFileContext context)
        {
            IEmdFileStrcture retVal = m_resEmdFileStrcture.Resolve();
            using (var zipArchive = new ZipArchive(context.EmdFileStream, ZipArchiveMode.Read, true))
            {
                if (zipArchive.Entries.Count <= 0 || zipArchive.Entries.FirstOrDefault() == null)
                {
                    return retVal;
                }
                retVal.Name = context.ZipFileName;
                IEmdFileMember actualMember = null;
                foreach (var item in zipArchive.Entries)
                {
                    if (item.Length == 0)
	                {
                        string itemName = Path.GetFileName(Path.GetDirectoryName(item.FullName));
                        if (itemName.Contains("Beam."))
	                    {
                            actualMember = m_resEmdFileMember.Resolve();
                            actualMember.Name = itemName;
                            retVal.Members.Add(actualMember);
	                    }
                        continue;
	                }
                    if (item.Name == "Places.emd" && !String.IsNullOrEmpty(actualMember.Name))
                    {
                        PrepareSection4Member(actualMember, item);
                        continue;
                    }
                }
            }
            if (retVal.Members.Count <= 0 || retVal.Members.Any(item => item.Sections.Count <= 0))
            {
                return m_resEmdFileStrcture.Resolve();
            }
            return retVal;
        }

        #region METHODS
        void PrepareSection4Member(IEmdFileMember actualMember, ZipArchiveEntry item)
        {
            IEmdFileSection actSection = m_resEmdFileSection.Resolve();
            actSection.Index = 0;
            actSection.Position = 0.0;
            actualMember.Sections.Add(actSection);
            actSection = m_resEmdFileSection.Resolve();
            actSection.Index = 1;
            actSection.Position = 0.5;
            actualMember.Sections.Add(actSection);
            actSection = m_resEmdFileSection.Resolve();
            actSection.Index = 2;
            actSection.Position = 1.0;
            actualMember.Sections.Add(actSection);
        }
        #endregion

    }
}
