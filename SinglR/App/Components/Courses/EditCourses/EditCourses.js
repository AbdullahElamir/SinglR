export default {
    name: 'EditCourse',    
    created() {
        var Courses = this.$parent.CourseEdit;
        this.form.Name = Courses.name;
        this.form.Description = Courses.description;
        this.form.PricePersonal = Courses.pricePersonal;
        this.form.PriceCompany = Courses.priceCompany;
        this.form.Discount = Courses.discount;
        this.form.Color = Courses.color;
        this.form.CourseId = Courses.courseId;
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
                CourseId:'',
            },     
        };
    },
    methods: {
        Back() {
            this.$parent.state = 0;
        },

        Edit() {
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
         
            this.$http.EditCourse(this.form)
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
