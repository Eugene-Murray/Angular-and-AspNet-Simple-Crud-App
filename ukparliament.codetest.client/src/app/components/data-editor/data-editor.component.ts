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

  
  onSelectionChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const selectedDepartmentId = Number(selectElement.value);
    this.addEditPerson.departmentId = selectedDepartmentId;
    this.addEditPerson.departmentName = this.departments?.find(d => d.id === selectedDepartmentId)?.name || 'Unknown';
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
