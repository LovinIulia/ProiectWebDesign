import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Category } from '../interfaces/category';
import { Note } from '../interfaces/note';
import { CategoryService } from '../services/category.service';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.scss']
})
export class EditNoteComponent implements OnInit {
  categories: Category[] = [];
  noteToEdit: Note;

  constructor(
    private noteService: NoteService, 
    private categoryService: CategoryService, 
    private route: ActivatedRoute) {
    }

  ngOnInit(): void {
    this.categories= this.categoryService.getCategories();
    const id = this.route.snapshot.queryParamMap.get('noteId');
    this.noteService.getNote(id).subscribe((note: Note) => {this.noteToEdit = note} )
  }

  editNote() {
    this.noteService.editNote(this.noteToEdit).subscribe();
  }

}
