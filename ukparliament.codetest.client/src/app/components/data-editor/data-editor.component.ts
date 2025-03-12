import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Department, Person } from '../../models/models';

@Component({
  selector: 'app-data-editor',
  standalone: false,
  templateUrl: './data-editor.component.html',
  styleUrl: './data-editor.component.css'
})
export class DataEditorComponent {
  @Input() addEditPerson: Person = { id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 };
  @Input() departments: Department[] = [];
  @Output() newPerson = new EventEmitter<Person>();
  @Output() updatePerson = new EventEmitter<Person>();
  @Output() clearPersonEditor = new EventEmitter<Person>();
  selectedDepartmentId: number = 0;
  selectedDate: string = '2000-2-4';

  
  onSelectionChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedDepartmentId = Number(selectElement.value);
    console.log('Selected Person ID:', this.selectedDepartmentId);
  }

  addPerson() {
    this.newPerson.emit(this.addEditPerson);
  }

  editPerson() {
    this.updatePerson.emit(this.addEditPerson);
  }

  clearPerson() {
    this.clearPersonEditor.emit({ id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 });
  }
}
