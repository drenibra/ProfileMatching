import { Company } from './Company';

export interface JobPosition {
  id: number;
  title: string;
  description: string;
  skillSet: string;
  createdAt: Date;
  expiryDate: Date;
  companyId: number;
  company: Company;
  category: string;
}
