import { Component, OnInit } from '@angular/core';
import { Person, Department } from './models/models';
import { DataService } from './services/data.service';
import { map } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  people: Person[] = [];
  departments: Department[] = [];
  addEditPerson: Person = { id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 };
  successMessage = '';
  errorMessage = '';

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.getDepartments()
  }

  getDepartments() {
    this.dataService.getDepartments().subscribe(result => {
      this.departments = result;
      this.getPeople();
    });
  }

  getPeople() {
    this.dataService.getPersons().pipe(map(p => {
      return p.map(person => {
        return {
          ...person,
          departmentName: this.getDepartmentName(person.departmentId),
          //dob: new Date(person.dob).toLocaleDateString()
        }
      })
    })).subscribe(result => this.people = result);
  }

  addPerson(newPerson: Person) {
    this.clearMessages();
    this.dataService.createPerson(newPerson).subscribe(
      (result) => {
        result.departmentName = this.getDepartmentName(result.departmentId);
        this.people.push(result);
        console.warn('people add:', this.people);
        this.addEditPerson = { id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 };
        this.successMessage = 'New User Added';
      },
      (error) => {
        console.error(error);
        this.successMessage = '';
        this.errorMessage = error;
      }
    );
  }

  editPerson(updatePerson: Person) {
    this.clearMessages();
    this.dataService.updatePerson(updatePerson).subscribe(
      (result) => {
        this.successMessage = 'User Updated';
      },
      (error) => {
        console.error(error);
        this.successMessage = '';
        this.errorMessage = error;
      }
    );
  }

  onDelete(id: number) {
    this.clearMessages();
    this.dataService.deletePerson(id).subscribe(
      (result) => {
        const index = this.people.findIndex((p) => p.id === id);
        this.people.splice(index, 1);
        this.addEditPerson = { id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 };
        this.successMessage = 'User Deleted';
      },
      (error) => {
        console.error(error);
        this.successMessage = '';
        this.errorMessage = error;
      }
    );
  }

  selectedPersonToEdit(person: Person) {
    this.addEditPerson = person;
    this.clearMessages();
  }

  clearPerson(emptyPerson: Person) {
    this.addEditPerson = emptyPerson;
    this.clearMessages();
  }

  clearMessages() {
    this.successMessage = '';
    this.errorMessage = '';
  }

  getDepartmentName(departmentId: number) {
    return this.departments?.find(d => d.id === departmentId)?.name;
  }
}
