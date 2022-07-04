export interface WordEdit {
    id: number;
    value: string;
    translation: string;
    wordCollectionId: number;
    isModified: boolean;
    isDeleted: boolean;
}