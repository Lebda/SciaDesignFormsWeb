function UserSelectionViewModel(structure, member, sectionIndex, sectionPosition)
{
    // PRIVATE
    this.m_structure = structure;
    this.m_member = member;
    this.m_sectionIndex = sectionIndex;
    this.m_sectionPosition = sectionPosition;
    // INTERFACE
}

function UserSelectionViewModelGetSet(structure, member, sectionIndex, sectionPosition)
{
    var viewModel = new UserSelectionViewModel(structure, member, sectionIndex, sectionPosition);
    Object.defineProperty(viewModel, "structure", {
        get: function () { return this.m_structure },
        set: function (value) { this.m_structure = value }
    });
    Object.defineProperty(viewModel, "member", {
        get: function () { return this.m_member },
        set: function (value) { this.m_member = value }
    });
    Object.defineProperty(viewModel, "sectionIndex", {
        get: function () { return this.m_sectionIndex },
        set: function (value) { this.m_sectionIndex = value }
    });
    Object.defineProperty(viewModel, "sectionPosition", {
        get: function () { return this.m_sectionPosition },
        set: function (value) { this.m_sectionPosition = value }
    });
    return viewModel;
}