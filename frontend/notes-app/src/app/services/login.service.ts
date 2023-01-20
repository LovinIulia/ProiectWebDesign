import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Category } from '../interfaces/category';
import { Note } from '../interfaces/note';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  readonly baseUrl= "https://localhost:44315";
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };

  constructor(private httpClient: HttpClient) { }

  
  checkCredentials(username: string, password: string):Observable<boolean> {
    return this.httpClient.get<boolean>(this.baseUrl+'/login?username=' + username + "&password=" + password, this.httpOptions);
  }

  getNote(noteId: string):Observable<Note> {
    return this.httpClient.get<Note>(this.baseUrl+'/notes/note/' + noteId, this.httpOptions);
  }
}
