import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, FormsModule, NgForm } from '@angular/forms';
import { Status, UserSearchViewModel } from '../../../view-models/search/user-search.view-model';
import { NavbarComponent } from "../../navbar/navbar/navbar.component";

@Component({
  selector: 'app-user-search',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    NavbarComponent
],
  templateUrl: './user-search.component.html',
  styleUrl: './user-search.component.scss'
})
export class UserSearchComponent {
  searchQuery: string = '';
  visible:boolean = false;
  checkAll:boolean = false;
  idList: number[] = [];
  users:UserSearchViewModel[] = [
    { id: 1, username: 'john_doe', email: 'john@example.com', status: Status.Active, selected: false },
    { id: 2, username: 'jane_smith', email: 'jane@example.com', status: Status.Inactive, selected: false }
  ];

  constructor() 
  {

  }

  onSearch(): void {
    if (this.isValidEmail(this.searchQuery)) {
      console.log('Searching by Gmail:', this.searchQuery);
    } else if (this.isValidPhoneNumber(this.searchQuery)) {
      console.log('Searching by Phone Number:', this.searchQuery);
    } else {
      console.log('Invalid input. Please enter a valid Gmail address or phone number.');
    }
  }

  isValidEmail(query: string): boolean {
    const emailPattern = /^[a-zA-Z0-9._%+-]+@gmail\.com$/;
    return emailPattern.test(query);
  }

  isValidPhoneNumber(query: string): boolean {
    const phonePattern = /^[0-9]{3,13}$/; 
    return phonePattern.test(query);
  }

  selectAll(event: any): void {
    const isChecked = event.target.checked;
    this.users.forEach(user => user.selected = isChecked);
    this.onCheckBoxChange();
  }

  onCheckBoxChange(): void {
    const allUnchecked = this.users.every(user => !user.selected);
    const allChecked = this.users.every(user => user.selected);
    if (allUnchecked) {
      this.checkAll = false;
      if (this.visible == true) this.visible = false;
    }
    if (!allChecked) {
      this.checkAll = false;
    }
    if (allChecked) {
      this.checkAll = true;
    }
    if (!allUnchecked) {
      if (this.visible == false) this.visible = true;
    }
  }

  moreDetail(id: number): void {
    console.log('more detail:', id);
  }

  changeStatus(id:number, status: Status)
  {
    console.log(id, status);
  }
  changeMultiStatus()
  {

  }
}
