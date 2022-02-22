import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'idk-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss'],
})
export class ButtonComponent implements OnInit {
  @Input() label!: string;
  @Input() icon?: string;

  @Output() onClick = new EventEmitter();

  ngOnInit(): void {}

  public get iconPath(): string {
    return (this.icon!.endsWith('.svg') ? this.icon : `${this.icon}.svg`) ?? '';
  }

  public get hasIcon(): boolean {
    return !!this.icon;
  }
}
