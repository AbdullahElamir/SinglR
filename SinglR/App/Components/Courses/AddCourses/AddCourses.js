export default {
    name: 'AddCourse',    
    created() {
       
    },
    data() {
        return {
            pageNo: 1,
            pageSize: 10,
            pages: 0,
            form: {
                Name: '',
                Description: '',
                PricePersonal: '',
                PriceCompany: '',
                Discount: '',
                Color: '',
                SuperPackageId:''
            },
          
         
        };
    },
    methods: {
        Back() {
            this.$parent.state = 0;
        },

        Save() {
            if (!this.form.Name) {
                this.$message({
                    type: 'error',
                    message: 'الرجاء إدخال اسم الدورة'
                });
                return;
            }

            if (!this.form.PricePersonal) {
                this.$message({
                    type: 'error',
                    message: 'الرجاء إدخال السعر للأفراد'
                });
                return;
            }

            if (!this.form.PriceCompany) {
                this.$message({
                    type: 'error',
                    message: 'الرجاء إدخال السعر للشركات'
                });
                return;
            }

            if (!this.form.Discount) {
                this.$message({
                    type: 'error',
                    message: 'الرجاء إدخال التخفيض'
                });
                return;
            }
            if (!this.form.Color) {
                this.$message({
                    type: 'error',
                    message: 'الرجاء إدخال اللون'
                });
                return;
            }

            this.form.SuperPackageId = this.$parent.SuperPackageParent.superPackageId;
           
          

            this.$http.AddCourse(this.form)
                .then(response => {
                    this.$parent.state = 0;
                    this.$parent.GetCoursesBySuperPackageId();
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                })
                .catch((err) => {
                    this.$message({
                        type: 'error',
                        message: err.response.data
                    });
                });
        },
    }    
}
