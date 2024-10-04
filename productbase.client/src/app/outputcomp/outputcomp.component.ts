
import { Component, Output, EventEmitter  } from '@angular/core';

@Component({
  selector: 'outputcomp',
  templateUrl: './outputcomp.component.html',
  styleUrl: './outputcomp.component.css'
})
export class OutputcompComponent {
  @Output() outputdataevent = new EventEmitter<string>();
}
