import { HttpClient } from '@angular/common/http';
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

  public people: Person[] = [];
  public departments: Department[] = [];
  public addEditPerson: Person = { id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 };
  addUserSuccess: boolean = false;
  editUserSuccess: boolean = false;
  successMessage = '';
  errorMessage = '';
  constructor(private http: HttpClient, private dataService: DataService) { }


  // Property to bind the selected option
  selectedDepartmentId: number = 0;
  selectedDate: string = '2000-2-4';

  // Method to handle the selection change
  onSelectionChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedDepartmentId = Number(selectElement.value);
    console.log('Selected Person ID:', this.selectedDepartmentId);
  }

  ngOnInit() {
    this.getDepartments()
    this.getPeople();
  }

  selectedPersonToEdit(person: Person) {
    this.addEditPerson = person;
  }

  getDepartments() {
    this.dataService.getDepartments().subscribe(result => this.departments = result);
  }

  getPeople() {
    this.dataService.getPersons().pipe(map(p => {
      return p.map(person => {
        return {
          ...person,
          departmentName: this.departments?.find(d => d.id === person.departmentId)?.name || 'Unknown',
          //dob: new Date(person.dob).toLocaleDateString()
        }
      })
    })).subscribe(result => this.people = result);
  }

  addPerson(newPerson: Person) {
    this.dataService.createPerson(newPerson).subscribe(
      (result) => {
        console.warn(result);
        this.people.push(result);
        this.addEditPerson = { id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 };
        this.addUserSuccess = true;
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
    this.dataService.updatePerson(updatePerson).subscribe(
      (result) => {
        this.addEditPerson = { id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 };
        //this.people.push(result);
        this.editUserSuccess = true;
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
    this.dataService.deletePerson(id).subscribe(
      (result) => {
        const index = this.people.findIndex((p) => p.id === id);
        this.people.splice(index);
        this.addEditPerson = { id: 0, firstName: '', lastName: '', dob: '', departmentId: 0 };
        this.editUserSuccess = true;
        this.successMessage = 'User Deleted';
      },
      (error) => {
        console.error(error);
        this.successMessage = '';
        this.errorMessage = error;
      }
    );
  }

  selectPerson(person: Person) {
    this.addEditPerson = person;
  }

  clearPerson(emptyPerson: Person) {
    this.addEditPerson = emptyPerson;
  }
}
