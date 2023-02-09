import { Company } from './Company';

export interface Recruiter {
  companyId: number;
  company: Company;
  dateStarted: Date;
}
