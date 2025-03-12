import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Person } from '../../models/models';

@Component({
  selector: 'app-data-table',
  standalone: false,
  templateUrl: './data-table.component.html',
  styleUrl: './data-table.component.css'
})
export class DataTableComponent {
  @Input() peopleList: Person[] = [];
  @Output() selectedPersonToEdit = new EventEmitter<Person>();
  @Output() selectedPersonToDelete = new EventEmitter<number>();
  selectedPerson: Person = { id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 };

  selectPerson(person: Person) {
    this.selectedPerson = person;
    this.selectedPerson.isEdit = true;
    this.selectedPersonToEdit.emit(person);
  }

  onDelete(id: number) {
    this.selectedPersonToDelete.emit(id);
  }
}

