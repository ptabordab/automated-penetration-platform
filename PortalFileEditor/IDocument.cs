namespace PortalFileEditor
{
    public interface IDocument
    {
        DocumentKind Kind { get; }

        /// <summary>Full path when saved or opened; empty for new documents.</summary>
        string FilePath { get; set; }

        bool IsDirty { get; set; }

        void LoadFromFile(string path);

        void SaveToFile(string path);

        /// <summary>Mark clean after successful save/load.</summary>
        void ClearDirty();
    }
}
