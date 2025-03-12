export interface Person {
  id: number;
  firstName: string;
  lastName: string;
  dob: string;
  departmentId: number;
  departmentName?: string;
}

export interface Department {
  id: number;
  name: string;
}
