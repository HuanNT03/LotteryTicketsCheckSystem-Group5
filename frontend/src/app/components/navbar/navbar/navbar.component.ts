import { Component, HostListener, ElementRef, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  user:string = "Username";
  admin:string = "Admin";
  public isAuthenticated:boolean = false;
  public isAdmin:boolean = false;
  public visible:boolean = false;
  // noUserNavbarItems:string[] = ["Trang chủ", "Trúng thưởng"];
  // userNavbarItems:string[] = ["Trang chủ", "Trúng thưởng", "Lịch sử"];
  // adminNavbarItems:string[] = ["Quản lý người dùng", "Quản lý vé số"];
  constructor()
  {

  }
  @ViewChild('excludedArea1') excludedArea1!: ElementRef;
  @ViewChild('excludedArea2') excludedArea2!: ElementRef;

  @HostListener('document:click', ['$event'])
  handleDocumentClick(event:MouseEvent)
  {
    if(this.visible)
    {
      const clickedInsideArea1 = this.excludedArea1.nativeElement.contains(event.target);
      const clickedInsideArea2 = this.excludedArea2.nativeElement.contains(event.target);

      if(this.isAdmin || this.isAuthenticated)
      {
        if (!clickedInsideArea1 && !clickedInsideArea2)
        {
          this.visible = false;
        }
      }
    }
  }

  onClick()
  {
    if(this.isAdmin || this.isAuthenticated)
    {
      if(!this.visible) this.visible = true;
      else this.visible = false;
    }
  }

  logOut()
  {

  }
}
