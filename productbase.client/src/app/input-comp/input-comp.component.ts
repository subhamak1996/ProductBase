import { Component,Input } from '@angular/core';

@Component({
  selector: 'inputcomp',
  templateUrl: './input-comp.component.html',
  styleUrl: './input-comp.component.css'
})
export class InputCompComponent {
  @Input() item: string | undefined;
}
