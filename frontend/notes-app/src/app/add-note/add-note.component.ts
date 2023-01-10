import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Category } from '../interfaces/category';
import { Note } from '../interfaces/note';
import { CategoryService } from '../services/category.service';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit { 
  //id: string;
  title: string;
  description: string;
  categories: Category[] = [];
  selectedCategory: string;
  
  constructor(
    private noteService: NoteService,
     private categoryService: CategoryService) { 
     }

  ngOnInit(): void {
    this.categories= this.categoryService.getCategories();
  }
  
  //addNote(title: string, description: string, category: Category) {    
     //this.noteService.addNote(title, description, category);  
   //}
   
   addNote() {
     
     let guid = Guid.create();
     const note: Note = {
      id: guid.toString(),
      title: this.title,
      description: this.description,
      categoryId: this.selectedCategory
    }

     this.noteService.addNote(note).subscribe(a => this.noteService.getNotes());
   }
}
