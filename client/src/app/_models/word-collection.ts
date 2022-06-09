import { Word } from "./word";

export interface WordCollection {
    id: number;
    name: string;
    themeName: string;
    description: string;
    words: Word[];
}