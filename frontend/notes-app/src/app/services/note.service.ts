import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Category } from '../interfaces/category';
import { Note } from '../interfaces/note';

@Injectable({
  providedIn: 'root'
})
export class NoteService {
  // notes: Note[]=[
  //   {
  //     id: "Id1",
  //     title: "First note",
  //     description: "This is the description for the first note",
  //     category: "1"
  //   },
  //   {
  //     id: "Id2",
  //     title: "Second note",
  //     description: "This is the description for the second note",
  //     category: "2"
  //   },
  //   {
  //     id: "Id3",
  //     title: "Third note",
  //     description: "This is the description for the third note",
  //     category: "3"
  //   }
  // ];

  readonly baseUrl= "https://localhost:44315";
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };

  constructor(private httpClient: HttpClient) { }

  getNotes():Observable<Note[]> {
    return this.httpClient.get<Note[]>(this.baseUrl+'/notes', this.httpOptions);
  }

  getNote(noteId: string):Observable<Note> {
    return this.httpClient.get<Note>(this.baseUrl+'/notes/note/' + noteId, this.httpOptions);
  }

  getFilteredNotes(argCategory: string) {
       return this.httpClient.get<Note[]>(this.baseUrl+'/notes', this.httpOptions).pipe(map((notes: Note[]) => {
        return notes.filter(note => note.categoryId === argCategory);
       }));
  }

  getFiltredNotesByTitle(argTitle: string) {
    return this.httpClient.get<Note[]>(this.baseUrl+'/notes', this.httpOptions).pipe(map((notes: Note[]) => {
     return notes.filter(note => note.title.toLowerCase().includes(argTitle.toLowerCase())
      || note.description.toLowerCase().includes(argTitle.toLowerCase()));
    }));
  }

  addNote(note: Note) {
    return this.httpClient.post(this.baseUrl+'/notes', note, this.httpOptions);
  }

  deleteNote(id: string) {
    return this.httpClient.delete(this.baseUrl+'/notes/note/' + id);
  }

  editNote(note: Note) {
    return this.httpClient.put(this.baseUrl+'/notes', note, this.httpOptions);
  }

  // serviceCall() {
  //   console.log("Note service was called");
  // }

  // getNotes() {
  //   return this.notes;
  // }

  // addNote(title: string, description: string, category: Category)
  // {
  //   const note: Note = {id : "1", title : title, description : description, category: "1"}
  //   this.notes.push(note);
  // }

  // getFiltredNotes(argCategory: string) {
  //   return this.notes.filter(note => note.category === argCategory);
  // }

  // getFiltredNotesByTitle(argTitle: string) {
  //   return this.notes.filter(note => note.title.toLowerCase().includes(argTitle.toLowerCase()) 
  //   || note.description.toLowerCase().includes(argTitle.toLowerCase()));
  // }

}
