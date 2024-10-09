import { Component,Output,EventEmitter } from '@angular/core';

@Component({
  selector: 'outputcomp',
  templateUrl: './output-comp.component.html',
  styleUrl: './output-comp.component.css'
})
export class OutputCompComponent {
  @Output() Outpuddataevent = new EventEmitter<string>();
}
