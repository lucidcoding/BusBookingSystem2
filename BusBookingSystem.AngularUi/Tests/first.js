describe("A suite", function () {
    it("contains spec with an expectation", function () {
        expect(true).toBe(true);
    });

    it("fails", function () {
        expect(true).toBe(false);
    });
});