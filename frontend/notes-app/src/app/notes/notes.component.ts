import { Component, Input, OnChanges, OnInit, SimpleChanges, ɵisDefaultChangeDetectionStrategy } from '@angular/core';
import { Note } from '../interfaces/note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-note',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit, OnChanges {
  id: string;
  title: string;
  description: string;
  notes: Note[] = [];

  @Input() selectedCategory: string;
  @Input() selectedNote: string;

  constructor(private service: NoteService) { }
  
  ngOnInit(): void {
     this.service.getNotes().subscribe((notes: Note[]) => {this.notes = notes} );
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log("ngOnchanges was called");
    if (this.selectedCategory) 
    {
      this.service.getFilteredNotes(this.selectedCategory).subscribe((notes: Note[]) => {this.notes = notes} )
    }
    else if(this.selectedNote)
    {
      this.service.getFiltredNotesByTitle(this.selectedNote).subscribe((notes: Note[]) => {this.notes = notes} )
    }
  }

  deleteNote(id: string) {
    console.log('id is : ' + id);
    this.service.deleteNote(id).subscribe();
  }
}
