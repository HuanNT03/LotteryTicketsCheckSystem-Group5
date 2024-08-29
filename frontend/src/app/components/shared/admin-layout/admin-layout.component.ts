import { Component } from '@angular/core';
import { NavbarComponent } from "../../navbar/navbar/navbar.component";

@Component({
  selector: 'app-admin-layout',
  standalone: true,
  imports: [NavbarComponent],
  templateUrl: './admin-layout.component.html',
  styleUrl: './admin-layout.component.scss'
})
export class AdminLayoutComponent {

}
